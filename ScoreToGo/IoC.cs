using Autofac;
using ScoreToGo.Controllers;
using ScoreToGo.Mappers;
using ScoreToGo.Mappers.Interfaces;
using STG.Business.Logic;
using STG.Business.Logic.Interfaces;
using STG.DataAccess.AccessObjects;
using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.AccessObjects.Raven;
using STG.DataAccess.Connections;
using STG.Business.Mappers;
using STG.Business.Mappers.DomainAndDataAccess;
using System;
using STG.DataAccess.DataModels;
using STG.Business.DomainModels;
using ScoreToGo.Models;

namespace ScoreToGo
{
    public static class IoC
    {
        private static IContainer _container;

        private static readonly ContainerBuilder _builder = new ContainerBuilder();

        private static IContainer Container
        {
            get
            {
                if (_container != null)
                    return _container;
                _container = _builder.Build();
                return _container;
            }
        }

        public static void Setup()
        {
            //DataAccess
            _builder.RegisterType<RavenGameAccess>().As<IGameAccess>();
            _builder.RegisterType<SqlDatabaseConnection>().As<IDatabaseConnection>();

            //Mappers Business - DateAccess
            _builder.RegisterType<GamePlayMapper>().As<IModelMapper<DomainGamePlay, GamePlay>>().SingleInstance();
            _builder.RegisterType<GameMapper>().As<IModelMapper<DomainGame, Game>>().SingleInstance();

            //Business
            _builder.RegisterType<RotationBusiness>().As<IRotationBusiness>();
            _builder.RegisterType<GameBusiness>().As<IGameBusiness>();

            //Mappers Controller - Business
            _builder.RegisterType<RotationModelMapper>().As<IRotationModelMapper>();
            _builder.RegisterType<GamePlayModelMapper>().As<IGamePlayModelMapper>();
            _builder.RegisterType<GameModelMapper>().As<IModelMapper<GameModel, DomainGame>>().SingleInstance();

            //Controllers
            _builder.RegisterType<HomeController>();
            _builder.RegisterType<RotationController>();
            _builder.RegisterType<GameController>();
            _builder.RegisterType<GameSetUpController>();
        }

        public static T ResolveDependency<T>()
        {
            return Container.Resolve<T>();
        }

        public static object ResolveDependency(Type type)
        {
            return Container.Resolve(type);
        }
    }
}