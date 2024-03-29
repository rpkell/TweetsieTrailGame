﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextPresenter : ITextPresenter
    {
        private ITextViewer viewer;

        public TextPresenter(ITextViewer textViewer)
        {
            viewer = textViewer;
        }

        public void showTextUIModel(TextUIModel uiModel)
        {
            TextViewModel viewModel = new TextViewModel();
            foreach(string line in uiModel.Header)
            {
                viewModel.Lines.Add(line + "\n");
            }
            for(int i = 0; i < uiModel.Options.Count; ++i)
            {
                viewModel.Lines.Add((i + 1) + ". " + uiModel.Options[i] + "\n");
            }
            viewModel.Lines.Add(uiModel.InputPrompt);
            viewer.displayText(viewModel);
        }

        //public void showOpeningScreen()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("Tweetsie Trail Game");
        //    viewModel.Lines.Add("Press any key to continue");
        //    viewer.displayText(viewModel);
        //}
        //public void showContinue()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("Press any key to continue");
        //    viewer.displayText(viewModel);
        //}

        //public void showExitMessage()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("Thank you for playing Tweetsie Trail");
        //    viewer.displayText(viewModel);
        //}

        //public void showMoney()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("You have $" + Shopping.Money);
        //    viewer.displayText(viewModel);
        //}

        //public void showNameRequest()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("What is your character's name?");
        //    viewer.displayText(viewModel);
        //}

        //public void showDecideJob()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("Choose a job and press the corresponding number");
        //    viewModel.Lines.Add("1.) Banker: 100 health, 15 strength, + $100 starting money, 1.2x score multiplier");
        //    viewModel.Lines.Add("2.) Fighter: 100 health, 25 strength, - $50 starting money, 1.2x score multiplier");
        //    viewer.displayText(viewModel);
        //}

        //public void showErrorMessage()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("Something went wrong. Let's try that again.");
        //    viewer.displayText(viewModel);
        //}

        //public void showMainMenuOptions()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("1.) Start Game");
        //    viewModel.Lines.Add("2.) Display HighScores");
        //    viewModel.Lines.Add("3.) Exit");
        //    viewer.displayText(viewModel);
        //}
        //public void showShopping()
        //{
        //    /*
        //    TextViewModel viewModel = new TextViewModel();
        //    viewModel.Lines.Add("");
        //    viewModel.Lines.Add("Each wheel is $50. How many would you like to buy?");
        //    */
        //}
        //public void showScores()
        //{
        //    TextViewModel viewModel = new TextViewModel();
        //    string[] lines = File.ReadAllLines(ScoreTable.filePath);
        //    viewModel.Lines.Add("");
        //    foreach (string line in lines)
        //        viewModel.Lines.Add(line);
        //    viewer.displayText(viewModel);
        //}

        //public void showTravel()
        //{

        //}
    }
}
