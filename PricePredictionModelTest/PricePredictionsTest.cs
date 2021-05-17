using System;
using Xunit;
using PricePredictionML.Model;


namespace PricePredictionModelTest
{
    public class PricePredictionTests
    {
        private readonly ConsumeModel consumeModel;

        public PricePredictionTests()
        {
            consumeModel = new ConsumeModel();
        }
        [Fact]
        public void Given_AnTelevisionProductFromDataTrain_Then_PredictShouldPredictASpecificPrice1()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "LG",
                Series = "series 2",
                Consumption = 85,
                EnergyClass = "A++",
                Colour = "yellow",
                Weight = 23,
                Diagonal = "214",
                IsSmart = "TRUE",
                Resolution = "HD",
                Type = "Television"
            };
           var response =  ConsumeModel.Predict(modelInput);
           Assert.Equal(706, (int)response.Score);
        }
        [Fact]
        public void Given_AnTelevisionProductFromDataTrain_Then_PredictShouldPredictASpecificPrice2()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Samsung",
                Series = "series 3",
                Consumption = 85,
                EnergyClass = "A++",
                Colour = "red",
                Weight = 50,
                Diagonal = "100",
                IsSmart = "TRUE",
                Resolution = "HD",
                Type = "Television"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(745, (int)response.Score);
        }


        [Fact]
        public void Given_AnBlenderProductFromDataTrain_Then_PredictShouldPredictASpecificPrice1()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Horizon",
                Series = "series 1",
                Colour = "silver",
                Weight = 19,
                Type = "Blender",
               
              
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(575, (int)response.Score);
        }
        [Fact]
        public void Given_AnBlenderProductFromDataTrain_Then_PredictShouldPredictASpecificPrice2()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Horizon",
                Series = "series 6",
                Colour = "red",
                Weight = 2,
                Type = "Blender"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(675, (int)response.Score);
        }

        [Fact]
        public void Given_AnFridgeProductFromDataTrain_Then_PredictShouldPredictASpecificPrice1()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Panasonic",
                Series = "series 1",
                Consumption = 300,
                EnergyClass = "A++",
                Colour = "white",
                Weight = 23,
                Depth = "2",
                Doors = "1",
                HasFreezer = "TRUE",
                Height = "181",
                Volume = "300",
                Width = "79",
                Type = "Fridge"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(769, (int)response.Score);
        }
        [Fact]
        public void Given_AnFridgeProductFromDataTrain_Then_PredictShouldPredictASpecificPrice2()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Samsung",
                Series = "series 3",
                Consumption = 200,
                EnergyClass = "A++",
                Colour = "silver",
                Weight = 13,
                Depth = "1",
                Doors = "1",
                HasFreezer = "TRUE",
                Height = "90",
                Volume = "300",
                Width = "79",
                Type = "Fridge"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(944, (int)response.Score);
        }

        [Fact]
        public void Given_AnPhoneProductFromDataTrain_Then_PredictShouldPredictASpecificPrice1()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Apple",
                Series = "series 1",
                Colour = "Blue",
                Weight = 20,
                Bluetooth = "4.2",
                Wifi = "5",
                Software ="IOS",
                Camera = "12MP",
                FrontalCamera = "10MP",
                SimSlots = "1",
                RAM ="8GB",
                Memory = "16GB",
                Connectivity = "3G",
                Diagonal = "6.5",
                Type = "Phone"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(650, (int)response.Score);
        }
        [Fact]
        public void Given_AnPhoneProductFromDataTrain_Then_PredictShouldPredictASpecificPrice2()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Apple",
                Series = "series 1",
                Colour = "red",
                Weight = 21,
                Bluetooth = "4.1",
                Wifi = "6",
                Software = "Android 9",
                Camera = "108MP",
                FrontalCamera = "8MP",
                SimSlots = "1",
                RAM = "4GB",
                Memory = "128GB",
                Connectivity = "3G",
                Diagonal = "6",
                Type = "Phone"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(652, (int)response.Score);
        }


        [Fact]
        public void Given_AnMicrowaveProductFromDataTrain_Then_PredictShouldPredictASpecificPrice1()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Horizon",
                Series = "series 3",
                Colour = "black",
                Weight = 3,
                Depth = "50",
                Height = "40",
                Volume = "50",
                Width = "60",
                Type = "Microwave"


            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(607, (int)response.Score);
        }
        [Fact]
        public void Given_AnMicrowaveProductFromDataTrain_Then_PredictShouldPredictASpecificPrice2()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Horizon",
                Series = "series 6",
                Colour = "red",
                Weight = 2,
                Depth ="60",
                Height = "35",
                Volume = "20",
                Width = "57",
                Type = "Microwave"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(676, (int)response.Score);
        }

        [Fact]
        public void Given_AnVacuumCleanerProductFromDataTrain_Then_PredictShouldPredictASpecificPrice1()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Panasonic",
                Series = "series 1",
                Consumption = 300,
                EnergyClass = "A++",
                Colour = "white",
                Weight = 23,
                Depth = "2",
                Doors = "1",
                HasFreezer = "TRUE",
                Height = "181",
                Volume = "300",
                Width = "79",
                Type = "Vacuum"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(769, (int)response.Score);
        }
        [Fact]
        public void Given_AnVacuumClenerProductFromDataTrain_Then_PredictShouldPredictASpecificPrice2()
        {
            ModelInput modelInput = new ModelInput()
            {
                Brand = "Samsung",
                Series = "series 3",
                Consumption = 200,
                EnergyClass = "A++",
                Colour = "silver",
                Weight = 13,
                Depth = "1",
                Doors = "1",
                HasFreezer = "TRUE",
                Height = "90",
                Volume = "300",
                Width = "79",
                Type = "Vacuum"
            };
            var response = ConsumeModel.Predict(modelInput);
            Assert.Equal(945, (int)response.Score);
        }

    }
}
