using Domain.Exceptions;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Factories.PetsFactory
{
    public class PetsFactorySpecs
    {
        [Fact]
        public void BuildShouldNotThrowExceptionWhenParametersValid()
        {
            //Arrange
            var petsFactory = new PetsFactory();

            //Act
            Action act = () => petsFactory
            .WithName("some name")
            .WithAge(2)
            .WithOwner(A.Dummy<Owner>())
            .WithPictureUrl("https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg")
            .WithSpicie(A.Dummy<Spicie>())
            .Build();

            //Asert
            act.Should().NotThrow<InvalidPetException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenNameNotSet()
        {
            //Arrange
            var petsFactory = new PetsFactory();

            //Act
            Action act = () => petsFactory
            .WithAge(2)
            .WithOwner(A.Dummy<Owner>())
            .WithPictureUrl("https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg")
            .WithSpicie(A.Dummy<Spicie>())
            .Build();

            //Asert
            act.Should().Throw<InvalidPetException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenAgeNotSet()
        {
            var petsFactory = new PetsFactory();

            //Act
            Action act = () => petsFactory
            .WithName("some name")
            .WithOwner(A.Dummy<Owner>())
            .WithPictureUrl("https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg")
            .WithSpicie(A.Dummy<Spicie>())
            .Build();

            //Asert
            act.Should().Throw<InvalidPetException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenOwnerNotSet()
        {
            var petsFactory = new PetsFactory();

            //Act
            Action act = () => petsFactory
            .WithName("some name")
            .WithAge(2)
            .WithPictureUrl("https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg")
            .WithSpicie(A.Dummy<Spicie>())
            .Build();

            //Asert
            act.Should().Throw<InvalidPetException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenPicNotSet()
        {
            var petsFactory = new PetsFactory();

            //Act
            Action act = () => petsFactory
            .WithName("some name")
            .WithAge(2)
            .WithOwner(A.Dummy<Owner>())
            .WithSpicie(A.Dummy<Spicie>())
            .Build();

            //Asert
            act.Should().Throw<InvalidPetException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenSpicieNotSet()
        {
            var petsFactory = new PetsFactory();

            //Act
            Action act = () => petsFactory
            .WithName("some name")
            .WithAge(2)
            .WithOwner(A.Dummy<Owner>())
            .WithPictureUrl("https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg")
            .Build();

            //Asert
            act.Should().Throw<InvalidPetException>();
        }

    }
}
