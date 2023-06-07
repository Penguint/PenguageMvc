using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PenguageMvc.Data;
using System;
using System.Linq;

namespace PenguageMvc.Models;

public static class SeedData
{
    public static void InitializeQuestion(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            // Look for any questions.
            if (context.Question.Any())
            {
                return;   // DB has been seeded
            }
            context.MultipleChoiceQuestion.AddRange(
                new MultipleChoiceQuestion
                {
                    Language = "Spanish",
                    Stem = "What is the Spanish word for \"hello\" ?",
                    CorrectAnswer = "hola",
                    Distractor1 = "adiós",
                    Distractor2 = "gracias",
                    Distractor3 = "por favor",
                    Explanation = "The Spanish word for \"hello\" is \"hola.\""
                },
                new MultipleChoiceQuestion
                {
                    Language = "Spanish",
                    Stem = "Which of the following means \"goodbye\" in Spanish?",
                    CorrectAnswer = "adiós",
                    Distractor1 = "hola",
                    Distractor2 = "gracias",
                    Distractor3 = "por favor",
                    Explanation = "The Spanish word for \"hello\" is \"hola.\""
                },
                new MultipleChoiceQuestion
                {
                    Language = "Spanish",
                    Stem = "What does \"amigo\" mean in English?",
                    CorrectAnswer = "friend",
                    Distractor1 = "house",
                    Distractor2 = "cat",
                    Distractor3 = "food",
                    Explanation = "\"Amigo\" means \"friend\" in English."
                },
                new MultipleChoiceQuestion
                {
                    Language = "Japanese",
                    Stem = "Which characer has the same pronunciation as \"a\"?",
                    CorrectAnswer = "あ",
                    Distractor1 = "い",
                    Distractor2 = "う",
                    Distractor3 = "え",
                    Explanation = "あ is pronounced as \"a.\" い is pronounced as \"i,\" う is pronounced as \"u,\" and え is pronounced as \"e.\""
                },
                new MultipleChoiceQuestion
                {
                    Language = "Japanese",
                    Stem = "Which characer has the same pronunciation as \"ka\"?",
                    CorrectAnswer = "か",
                    Distractor1 = "き",
                    Distractor2 = "こ",
                    Distractor3 = "く",
                    Explanation = "か is pronounced as \"ka.\" き is pronounced as \"ki,\" こ is pronounced as \"ko,\" and く is pronounced as \"ku.\""
                },
                new MultipleChoiceQuestion
                {
                    Language = "Japanese",
                    Stem = "Which characer has the same pronunciation as \"ka\"?",
                    CorrectAnswer = "カ",
                    Distractor1 = "キ",
                    Distractor2 = "ク",
                    Distractor3 = "ケ",
                    Explanation = "カ is pronounced as \"ka.\" キ is pronounced as \"ki,\" ク is pronounced as \"ku,\" and ケ is pronounced as \"ke.\""
                },
                new MultipleChoiceQuestion
                {
                    Language = "Chinese",
                    Stem = "What does \"你好(nǐ hǎo)\" mean?",
                    CorrectAnswer = "Hello",
                    Distractor1 = "Thank you",
                    Distractor2 = "Goodbye",
                    Distractor3 = "Sorry",
                    Explanation = "\"你好\" (nǐ hǎo) is a common greeting in Chinese, which means \"hello\" or \"hi.\""
                },
                new MultipleChoiceQuestion
                {
                    Language = "Chinese",
                    Stem = "Which word means \"thank you\" in Chinese?",
                    CorrectAnswer = "谢谢 (xiè xiè)",
                    Distractor1 = "对不起 (duì bù qǐ)",
                    Distractor2 = "再见 (zài jiàn)",
                    Distractor3 = "不好意思 (bù hǎo yì si)",
                    Explanation = "\"谢谢 (xièxiè)\" is the word for \"thank you\" in Chinese."
                },
                new MultipleChoiceQuestion
                {
                    Language = "Chinese",
                    Stem = "Which word means \"yes\" in Chinese?",
                    CorrectAnswer = "是 (shì)",
                    Distractor1 = "不 (bù)",
                    Distractor2 = "没有 (méi yǒu)",
                    Distractor3 = "可能 (kě néng)",
                    Explanation = "\"是 (shì)\" is the word for \"yes\" in Chinese."
                }
            );
            context.SaveChanges();
        }
    }

    public static async Task InitializeRoleAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
        var roles = new[] { "Admin", "User" };
        foreach (var role in roles)
        {
            var roleExist = await roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    public static async Task InitializeUserAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var defaultUser = new ApplicationUser
        {
            UserName = "Admin"
        };
        // if don't have this user, create the default user
        var defaultUserExist = await userManager.FindByNameAsync(defaultUser.UserName);
        if (defaultUserExist == null)
        {
            await userManager.CreateAsync(defaultUser, "Admin@123");
            await userManager.AddToRoleAsync(defaultUser, "Admin");
        }
    }
}
