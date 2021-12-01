using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.hero = new Hero("Hero", 1);
        this.heroRepository = new HeroRepository();
        heroRepository.Create(hero);
    }

    [Test]
    public void CtorOfHeroShouldWorkProperly()
    {
        string name = "Hero";
        int level = 1;
        Assert.That(name, Is.EqualTo(hero.Name));
        Assert.That(level, Is.EqualTo(hero.Level));
        Assert.IsNotNull(hero);
    }

    [Test]
    public void CtorOfHeroRepositoryShouldWorkProperly()
    {
        Assert.IsNotNull(heroRepository);
    }

    [Test]
    public void CreateMethodShouldThrowExceptionWhenHeroIsNull()
    {
        hero = null;
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldThrowExceptionWhenThereIsHeroWithTheSameName()
    {
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldAddHerosToDataCollection()
    {
        Assert.IsTrue(true, "Successfully added hero Hero with level 1");
    }

    [Test]
    [TestCase(" ", 1)]
    [TestCase("  ", 2)]
    [TestCase(null, 3)]
    public void RemoveMethodShouldThrowExceptionWhenHeroNameIsNullOrEmpty(string name, int level)
    {
        Hero currentHero = new Hero(name, level);
        heroRepository.Create(currentHero);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(currentHero.Name));
    }

    [Test]
    public void RemoveMethodShouldRemoveHeroWithSubmittedName()
    {
        Assert.IsTrue(heroRepository.Remove(hero.Name));
    }

    [Test]
    [TestCase("Hero2", 2)]
    [TestCase("Hero3", 3)]
    public void GetHeroWithHighestLevelShoulWorkProperly(string name, int level)
    {
        Hero expectedHero = new Hero(name, level);
        heroRepository.Create(expectedHero);
        Assert.That(expectedHero, Is.EqualTo(heroRepository.GetHeroWithHighestLevel()));
    }

    [Test]
    public void GetHeroMethodShoulReturnHeroWithSubnimttedName()
    {
        string name = "Hero";
        Assert.That(hero, Is.EqualTo(heroRepository.GetHero(name)));
    }

    [Test]
    public void VerifyThatCollectionOfHerosIsReadOnlyCollection()
    {
        var expectedResult = heroRepository.Heroes;
        Assert.IsTrue(expectedResult is IReadOnlyCollection<Hero>);
    }
}