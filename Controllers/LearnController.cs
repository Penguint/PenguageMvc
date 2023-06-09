﻿using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PenguageMvc.Data;
using PenguageMvc.Models;
using PenguageMvc.Models.Learn;

namespace PenguageMvc.Controllers;

public class LearnController : Controller
{
	private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

	public LearnController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
	{
		_context = context;
        _userManager = userManager;
	}

	private async Task<MultipleChoiceViewModel> _RandomMultipleChoiceViewModel()
	{
        var user = await _userManager.GetUserAsync(User);
        var language = user!.LanguageToLearn;

        var random = new Random();
        var multipleChoiceQuestion = _context.MultipleChoiceQuestion
            .Where(q => q.Language == language).ToList().OrderBy(q => random.Next())
            .FirstOrDefault();

        var stem = multipleChoiceQuestion!.Stem;
        var options = new List<string>() 
        {
            multipleChoiceQuestion!.CorrectAnswer!,
            multipleChoiceQuestion!.Distractor1!,
            multipleChoiceQuestion!.Distractor2!,
            multipleChoiceQuestion!.Distractor3!
        };
        options = options.OrderBy(x => random.Next()).ToList();

        return new MultipleChoiceViewModel
        {
            Id = multipleChoiceQuestion!.Id,
            Verified = false,
            Stem = stem,
            UserOptions = options
        };
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var learnViewModel = new IndexViewModel
        {
            QuestionView = "MultipleChoice",
            QuestionViewModel = await _RandomMultipleChoiceViewModel()
        };

        return View(learnViewModel);
	}

    [Authorize]
    public IActionResult Index(IndexViewModel learnViewModel)
    {
        return View(learnViewModel);
    }

    [Authorize]
    public async Task<IActionResult> MultipleChoice()
	{
		return View(await _RandomMultipleChoiceViewModel());
	}

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> MultipleChoice([Bind("Id,UserOptions,UserAnswer")]MultipleChoiceViewModel multipleChoiceViewModel)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        // Get the question by Id
        if (multipleChoiceViewModel.Id == null)
        {
            return NotFound();
        }
        var multipleChoiceQuestion = await _context.MultipleChoiceQuestion.FindAsync(multipleChoiceViewModel.Id);
        if (multipleChoiceQuestion == null)
        {
            return NotFound();
        }

        // Find the postion of the correct answer
        if (multipleChoiceViewModel.UserOptions == null)
        {
            return NotFound();
        }
        int truth = -1;
        for (int i = 0; i < multipleChoiceViewModel.UserOptions.Count; i++)
        {
            if (multipleChoiceViewModel.UserOptions[i] == multipleChoiceQuestion.CorrectAnswer)
            {
                truth = i;
                break;
            }
        }
        if (truth == -1)
        {
            return NotFound();
        }

        // Check if the answer is correct
        if (multipleChoiceViewModel.UserAnswer == null)
        {
            return NotFound();
        }
        var user = await _userManager.GetUserAsync(User);  // Get the current user
        if (user != null)
        {
            var learningRecord = new LearningRecord
            {
                User = user,
                Question = multipleChoiceQuestion,
                CompleteDate = DateTime.Now,
                Correct = multipleChoiceViewModel.UserAnswer == truth
            };
            _context.Add(learningRecord);
            await _context.SaveChangesAsync();
        }
        multipleChoiceViewModel.Verified = true;

        
        return View(new MultipleChoiceViewModel
        {
            Id = multipleChoiceQuestion.Id,
            Verified = true,
            Stem = multipleChoiceQuestion.Stem,
            UserOptions = multipleChoiceViewModel.UserOptions,
            UserAnswer = multipleChoiceViewModel.UserAnswer,
            Truth = truth,
            Explaination = multipleChoiceQuestion.Explanation
        });
    }
}
