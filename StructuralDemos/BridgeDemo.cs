using System;
using Structural.Bridge;
using Xunit;
using Xunit.Sdk;

namespace StructuralDemos
{
    public class BridgeDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public BridgeDemo(TestOutputHelper output) { _output = output; }
        [Fact]
        public void Cinema_FlatZwave_result()
        {
            ICinema cinema = CreateCinema(CinemaType.flat, EquipmentType.ZWave);
            _output.WriteLine(cinema.Show());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Stop());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Off());
        }
        
        [Fact]
        public void Cinema_FlatNoolite_result()
        {
            var cinema = CreateCinema(CinemaType.flat, EquipmentType.Noolite);
            _output.WriteLine(cinema.Show());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Stop());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Off());
        }

        [Fact]
        public void Cinema_CottageZwave_result()
        {
            var cinema = CreateCinema(CinemaType.cottadge, EquipmentType.ZWave);
            _output.WriteLine(cinema.Show());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Stop());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Off());
        }

        [Fact]
        public void Cinema_CottageNoolite_result()
        {
            var cinema = CreateCinema(CinemaType.cottadge, EquipmentType.Noolite);
            _output.WriteLine(cinema.Show());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Stop());
            _output.WriteLine("-----------------------------");
            _output.WriteLine(cinema.Off());
        }

        static ICinema CreateCinema(CinemaType ct, EquipmentType et)
        {
            IRelay projector, lamp1, lamp2;
            IEngine engine1, engine2;
            if (et == EquipmentType.Noolite)
            {
                projector = new RelayNoolite();
                lamp1 = new RelayNoolite();
                lamp2 = new RelayZWave();
                engine1 = new StepMotor();
                engine2 = new StepMotor();
            }
            else
            {
                projector = new RelayZWave();
                lamp1 = new RelayZWave();
                lamp2 = new RelayZWave();
                engine1 = new Motor();
                engine2 = new Motor();
            }
            
            switch (ct)
            {
                case CinemaType.flat:
                    return new CinemaFlat(lamp1, projector, engine1);
                case CinemaType.cottadge:
                    return new CinemaCottadge(projector, lamp1, lamp2, engine1, engine2);
                default:
                    return null;
            }
        }
    }
}