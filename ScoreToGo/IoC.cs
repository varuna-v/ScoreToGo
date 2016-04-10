﻿using Autofac;
using ScoreToGo.Controllers;
using ScoreToGo.Mappers;
using ScoreToGo.Mappers.Interfaces;
using STG.Business.Logic;
using STG.Business.Logic.Interfaces;
using STG.DataAccess.AccessObjects;
using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.AccessObjects.Raven;
using STG.DataAccess.Connections;
using System;

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
            //Mappers
            _builder.RegisterType<RotationModelMapper>().As<IRotationModelMapper>();
            _builder.RegisterType<GameModelMapper>().As<IGameModelMapper>();

            //Business
            _builder.RegisterType<RotationBusiness>().As<IRotationBusiness>();
            _builder.RegisterType<GameBusiness>().As<IGameBusiness>();

            //Controllers
            _builder.RegisterType<HomeController>();
            _builder.RegisterType<RotationController>();
            _builder.RegisterType<GameController>();

            //DataAccess
            _builder.RegisterType<RavenGameAccess>().As<IGameAccess>();
            _builder.RegisterType<SqlDatabaseConnection>().As<IDatabaseConnection>();
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