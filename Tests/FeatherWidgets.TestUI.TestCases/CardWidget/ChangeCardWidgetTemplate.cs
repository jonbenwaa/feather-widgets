﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feather.Widgets.TestUI.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatherWidgets.TestUI.TestCases.CardWidget
{
    /// <summary>
    /// ChangeCardWidgetTemplate test class.
    /// </summary>
    [TestClass]
    public class ChangeCardWidgetTemplate_ : FeatherTestCase
    {
        /// <summary>
        /// UI test ChangeCardWidgetTemplate
        /// </summary>
        [TestMethod,
        Owner(FeatherTeams.FeatherTeam),
        TestCategory(FeatherTestCategories.PagesAndContent),
        TestCategory(FeatherTestCategories.Card),
        TestCategory(FeatherTestCategories.Bootstrap)]
        public void ChangeCardWidgetTemplate()
        {
            BAT.Macros().NavigateTo().Pages(this.Culture);
            BAT.Wrappers().Backend().Pages().PagesWrapper().OpenPageZoneEditor(PageName);
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().EditWidget(WidgetName);
            BATFeather.Wrappers().Backend().Card().CardWrapper().FillHeadingText(HeadingText);
            BATFeather.Wrappers().Backend().Card().CardWrapper().FillTextArea(TextArea);
            BATFeather.Wrappers().Backend().Card().CardWrapper().ClickSelectImageButton();
            BATFeather.Wrappers().Backend().Media().MediaSelectorWrapper().WaitForContentToBeLoaded(isEmptyScreen: false);
            BATFeather.Wrappers().Backend().Media().MediaSelectorWrapper().SelectMediaFile(ImageTitle);
            BATFeather.Wrappers().Backend().Widgets().SelectorsWrapper().DoneSelecting();
            BATFeather.Wrappers().Backend().Card().CardWrapper().FillLabel(LabelText);
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerWrapper().ClickSelectButton(0);
            BATFeather.Wrappers().Backend().Widgets().SelectorsWrapper().SelectItemsInHierarchicalSelector(PageName2);
            BATFeather.Wrappers().Backend().Widgets().SelectorsWrapper().DoneSelecting();
            BATFeather.Wrappers().Backend().Navigation().NavigationWidgetEditWrapper().MoreOptions();
            BATFeather.Wrappers().Backend().Card().CardWrapper().SelectCardWidetTemplate(CardWidgetTemplate);
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerWrapper().SaveChanges();
            BAT.Wrappers().Backend().Pages().PageZoneEditorWrapper().PublishPage();

            BAT.Macros().NavigateTo().CustomPage("~/" + PageName.ToLower(), false, this.Culture);
            BATFeather.Wrappers().Frontend().Card().CardWrapper().VerifyCardWidgetContentOnFrontend(HeadingText, true);
            BATFeather.Wrappers().Frontend().Card().CardWrapper().VerifyCardWidgetContentOnFrontend(TextArea, true);
            BATFeather.Wrappers().Frontend().Card().CardWrapper().VerifyImageIsPresentOnFrontend(ImageTitle);
            BATFeather.Wrappers().Frontend().Card().CardWrapper().VerifyCardWidgetContentOnFrontend(LabelText, true);
            BATFeather.Wrappers().Frontend().Card().CardWrapper().VerifyPageIsPresentOnFrontend(LabelText, PageName2.ToLower());
        }

        /// <summary>
        /// Performs Server Setup and prepare the system with needed data.
        /// </summary>
        protected override void ServerSetup()
        {
            BAT.Macros().User().EnsureAdminLoggedIn();
            BAT.Arrange(this.TestName).ExecuteSetUp();
        }

        /// <summary>
        /// Performs clean up and clears all data created by the test.
        /// </summary>
        protected override void ServerCleanup()
        {
            BAT.Arrange(this.TestName).ExecuteTearDown();
        }

        private const string PageName = "CardPage";
        private const string PageName2 = "Page2";
        private const string ImageTitle = "Image1";
        private const string WidgetName = "Card";
        private const string HeadingText = "Heading text";
        private const string CardWidgetTemplate = "Card.Simple";
        private const string TextArea = "Text area text";
        private const string LabelText = "Label text";
    }
}
