// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
      
    [TestFixture]
    public class StageTests
    {
        private Performer performer;
        private Song song;
        private Stage stage;
        private List<Performer> performers;
        private List<Song> songs;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.performer = new Performer("FirstName", "LastName", 30);
            this.song = new Song("SongName", new TimeSpan(00, 04, 18));
            this.performers = new List<Performer>();
            this.songs = new List<Song>();
        }

        [Test]
        public void AddPerformerMethodSholudWorkProperly()
        {
            stage.AddPerformer(performer);
            Assert.That(1, Is.EqualTo(stage.Performers.Count));
        }

        [Test]
        public void AddPerformerShouldThrowAnExceptionWhenPerformerIsYangerThen18()
        {
            Performer yangPerformer = new Performer("FirstName", "LastName", 17);
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(yangPerformer));
        }

        [Test]
        public void AddPerformerShouldThrowAnExceptionWhenPerformerNameIsEmpty()
        {
            string name = string.Empty;
            Performer unnounPerformer = new Performer(name, name, 17);
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(unnounPerformer));
        }

        [Test]
        public void AddSongMethodSholudWorkProperly()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("SongName", "FirstName LastName");
            Assert.IsTrue(stage.Performers.Any(p => p.SongList.Contains(song)));
        }

        [Test]
        [TestCase("ShortSong1", 0, 0, 0)]
        [TestCase("ShortSong2", 0, 0, 1)]
        [TestCase("ShortSong3", 0, 0, 59)]
        public void AddSongShouldThrowAnExceptionWhenSongDurationIsShorterThenOneMinute(
            string name, int hours, int minutes, int seconds)
        {
            string songName = name;
            TimeSpan songDuration = new TimeSpan(hours, minutes, seconds);
            Song unknownSong = new Song(songName, songDuration);
            Assert.Throws<ArgumentException>(() => stage.AddSong(unknownSong));
        }

        [Test]
        public void AddSongToPerformerMethodSholudReturnMessage()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            string message = "SongName (04:18) will be performed by FirstName LastName";
            Assert.AreEqual(message, stage.AddSongToPerformer("SongName", "FirstName LastName"));
        }

        [Test]
        public void PlayMethodShouldWorkProperly()
        {
            Song songOne = new Song("FirstSong", new TimeSpan(00, 04, 18));
            Song songTwo = new Song("SecondSong", new TimeSpan(00, 03, 45));
            stage.AddPerformer(performer);
            stage.AddSong(songOne);
            stage.AddSong(songTwo);
            stage.AddSongToPerformer("FirstSong", "FirstName LastName");
            stage.AddSongToPerformer("SecondSong", "FirstName LastName");
            string exceptedMessage = "1 performers played 2 songs";
            Assert.That(exceptedMessage, Is.EqualTo(stage.Play()));
        }

        [Test]
        public void AddSongToPerformerMethodShouldThrowExceptionWhenThereIsNoPerformerWithThisName()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("SongName", "SecondName SurnameName"));
        }

        [Test]
        public void AddSongToPerformerMethodShouldThrowExceptionWhenThereIsNoSongWithThisName()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("SecondSong", "FirstName LastName"));
        }   
    }
}