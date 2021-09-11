using SteamDownloadMonitor.Core.Services;
using System.Collections.Generic;
using Xunit;

namespace SteamDownloadMonitor.Core.UnitTests.Services
{
    public class MutuallyExclusiveToggleStateTrackerTests
    {
        [Fact]
        public void GivenItem_WhenToggleItemStateOnce_ThenTrueReturned()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");

            // Act
            var result = sut.ToggleItemState("apple");

            // Assert
            Assert.True(result);
            Assert.True(sut.GetItemState("apple"));
        }

        [Fact]
        public void GivenItem_WhenToggleItemStateTwice_ThenFalseReturned()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");

            // Act
            var result = sut.ToggleItemState("apple");
            result = sut.ToggleItemState("apple");

            // Assert
            Assert.False(result);
            Assert.False(sut.GetItemState("apple"));
        }

        [Fact]
        public void GivenMultipleItems_AndSeveralStateChangeToggles_WhenGetSelected_ThenCorrectValueReturned()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");
            sut.AddItem("orange");
            sut.AddItem("pear");
            sut.ToggleItemState("apple");
            sut.ToggleItemState("orange");
            sut.ToggleItemState("pear");
            sut.ToggleItemState("orange");
            sut.ToggleItemState("orange");
            sut.ToggleItemState("apple");

            // Act
            var result = sut.GetSelected();

            // Assert
            Assert.Equal("apple", result);
            Assert.True(sut.GetItemState("apple"));
        }

        [Fact]
        public void GivenMultipleItems_AndSeveralExplicitStateChanges_WhenGetSelected_ThenCorrectValueReturned()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");
            sut.AddItem("orange");
            sut.AddItem("pear");
            sut.SetItemState("apple", true);
            sut.SetItemState("orange", true);
            sut.SetItemState("pear", true);
            sut.SetItemState("orange", true);
            sut.SetItemState("apple", false);

            // Act
            var result = sut.GetSelected();

            // Assert
            Assert.Equal("orange", result);
            Assert.True(sut.GetItemState("orange"));
        }

        [Fact]
        public void GivenMultipleItems_AndSeveralExplicitStateChanges_AndSetSelectedItemStateFalse_WhenGetSelected_ThenCorrectValueReturned()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");
            sut.AddItem("orange");
            sut.AddItem("pear");
            sut.SetItemState("apple", true);
            sut.SetItemState("orange", true);
            sut.SetItemState("pear", true);
            sut.SetItemState("orange", true);
            sut.SetItemState("orange", false);

            // Act
            var result = sut.GetSelected();

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GivenMultipleItems_WhenGetItemStateOfUnknownItem_ThenKeyNotFoundExceptionThrown()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");
            sut.AddItem("orange");
            sut.AddItem("pear");          

            // Act / Assert
            Assert.ThrowsAny<KeyNotFoundException>(() =>
            {
                var result = sut.GetItemState("banana");
            });
        }

        [Fact]
        public void GivenMultipleItems_AndRemoveItem_WhenGetRemovedItemState_ThenKeyNotFoundExceptionThrown()
        {
            // Arrange
            var sut = new MutuallyExclusiveToggleStateTracker();
            sut.AddItem("apple");
            sut.AddItem("orange");
            sut.AddItem("pear");
            sut.AddItem("banana");
            sut.RemoveItem("pear");

            // Act / Assert
            Assert.ThrowsAny<KeyNotFoundException>(() =>
            {
                var result = sut.GetItemState("pear");
            });
        }

    }
}
