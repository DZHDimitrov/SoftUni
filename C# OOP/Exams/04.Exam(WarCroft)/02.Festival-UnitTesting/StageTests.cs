// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

	[TestFixture]
	public class StageTests
	{
		[Test]
		public void AddPefromerShouldThrowAnExceptionIfRecievesNull()
		{
			Stage myStage = new Stage();
			Performer performer = null;
			Assert.Throws<ArgumentNullException>(() => myStage.AddPerformer(performer));
		}
		[Test]
		public void AddPerformerShouldThrowAnExceiptionIfThePerfomerIsLessThan18YearsOld()
		{
			Stage myStage = new Stage();
			Performer performer = new Performer("Pesho", "Peshev", 15);
			Assert.Throws<ArgumentException>(() => myStage.AddPerformer(performer));
		}
		[Test]
		public void AddPerfomerShouldWorkAsExpected()
		{
			Stage myStage = new Stage();
			Performer performer = new Performer("Pesho", "Peshev", 25);
			var myList = new List<Performer>();
			myList.Add(performer);
			myStage.AddPerformer(performer);

			CollectionAssert.AreEqual(myList, myStage.Performers);
		}
		[Test]
		public void AddSongShouldThrowAnExceptionIfRecievesNullValue()
		{
			Stage myStage = new Stage();
			Song song = null;
			Assert.Throws<ArgumentNullException>(() => myStage.AddSong(song));

		}
		[Test]
		public void AddSongShouldThrowAnExceptionIfRecievesSongWithDurationLessThanAMinute()
		{
			Stage myStage = new Stage();
			TimeSpan songTime = new TimeSpan(0, 0, 55);
			Song song1 = new Song("SomeSong", songTime);
			Assert.Throws<ArgumentException>(() => myStage.AddSong(song1));
			TimeSpan songTime2 = new TimeSpan(0, 0, 59);
			Song song2 = new Song("SomeSong2", songTime2);
			Assert.Throws<ArgumentException>(() => myStage.AddSong(song2));
		}

		[Test]
		public void AddSongShouldWorkAsExpected()
		{
			Stage myStage = new Stage();
			TimeSpan songTime = new TimeSpan(0, 1, 5);
			Performer perfomer = new Performer("Pesho", "Peshev", 25);
			myStage.AddPerformer(perfomer);
			Song song1 = new Song("SomeSong", songTime);
			var myList = new List<Song>();
			myList.Add(song1);
			myStage.AddSong(song1);
			myStage.AddSongToPerformer("SomeSong", "Pesho Peshev");
			CollectionAssert.AreEqual(myList, perfomer.SongList);
		}

		[Test]
		public void AddSongToPerformerShouldThrowAnExceptionIfRecievesNullValues()
		{
			Stage stage = new Stage();
			string performer = null;
			string song = null;
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(performer, song));
			Performer myPerformer = new Performer("Pesho", "Peshev", 25);
			stage.AddPerformer(myPerformer);
			TimeSpan songTime = new TimeSpan(0, 1, 5);
			Song mySong = new Song("SomeSong", songTime);
			stage.AddSong(mySong);
			var myMessage = "SomeSong (01:05) will be performed by Pesho Peshev";
			Assert.AreEqual(myMessage, stage.AddSongToPerformer("SomeSong", "Pesho Peshev"));
			var myList = new List<Song>();
			myList.Add(mySong);
			CollectionAssert.AreEqual(myList, myPerformer.SongList);
		}
		[Test]
		public void PlayShouldWorkAsExpected()
		{
			Stage stage = new Stage();
			Performer myPerformer1 = new Performer("Pesho", "Peshov", 25);
			Performer myPerformer2 = new Performer("Stoyan", "Iliev", 25);
			Performer myPerformer3 = new Performer("Jivko", "Ivanov", 25);
			Song song1 = new Song("SomeSong1", new TimeSpan(0, 1, 3));
			Song song2 = new Song("SomeSong2", new TimeSpan(0, 1, 4));
			Song song3 = new Song("SomeSong3", new TimeSpan(0, 1, 5));
			stage.AddPerformer(myPerformer1);
			stage.AddPerformer(myPerformer2);
			stage.AddPerformer(myPerformer3);
			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddSongToPerformer("SomeSong1", "Pesho Peshov");
			stage.AddSongToPerformer("SomeSong2", "Stoyan Iliev");
			stage.AddSongToPerformer("SomeSong3", "Jivko Ivanov");
			var message = $"3 performers played 3 songs";
			Assert.AreEqual(message, stage.Play());
		}

	}
}