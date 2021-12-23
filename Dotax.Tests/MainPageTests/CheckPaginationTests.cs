using Dotax.Utilities;
using NUnit.Framework;
using System;

namespace Dotax.Tests.MainPageTests
{
    internal class CheckPaginationTests : DotaxBaseTests
    {
        [SetUp]
        public void GetSearch()
        {
            mainPage.MainHeaderSection.Search(Categories.Books);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public void AssertPaginationContinueButton(int browsePages, int expectedPageNumber)
        {
            mainPage.ToNextPageByContinue(browsePages);

            Assert.That(mainPage.CheckActivePageNumber(expectedPageNumber),
                $"Test Failed, actual active page number is not {expectedPageNumber}.");
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public void AssertPaginationNextPageByNumber(int count, int expectedPageNumber)
        {
            mainPage.ToNextPage(count);

            Assert.That(mainPage.CheckActivePageNumber(expectedPageNumber),
                $"Test Failed, actual active page number is not {expectedPageNumber}.");
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        public void AssertPaginationNextPageByDotsMark(int count, int expectedPageNumber)
        {
            mainPage.ToNextPageByDots(count);

            Assert.That(mainPage.CheckActivePageNumber(expectedPageNumber),
                $"Test Failed, actual active page number is not {expectedPageNumber}.");
        }

        [TestCase(1, 249)]
        [TestCase(2, 248)]
        [TestCase(3, 247)]
        public void AssertPaginationBackButton(int browsePages, int expectedPageNumber)
        {
            mainPage.ToLastPage();
            mainPage.ToPrevPageByBack(browsePages);

            Assert.That(mainPage.CheckActivePageNumber(expectedPageNumber),
                $"Test Failed, actual active page number is not {expectedPageNumber}.");
        }

    }
}
