﻿using Autofac;
using ScoreToGo.Controllers;
using ScoreToGo.Mappers;
using ScoreToGo.Mappers.Interfaces;
using STG.Business.DomainModels;
using STG.Business.Logic;
using STG.Business.Logic.Interfaces;
using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.AccessObjects.Raven;
using STG.Domain.Mappers;
using STG.Domain.Models;
using System;

namespace ScoreToGo
{
    public static class InversionOfControl
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
            //Domain Mappers 
            _builder.RegisterType<Mapper>().As<IMapper>().SingleInstance();

            //DataAccess
            _builder.RegisterType<RavenDataAccess>().As<IAccessData>();
            _builder.RegisterType<RavenGameAccess>().As<IGameAccess>();
            
            //Business
            _builder.RegisterType<RotationBusiness>().As<IRotationBusiness>();
            _builder.RegisterType<TeamBusiness>().As<ITeamBusiness>();
            _builder.RegisterType<GamePlayBusiness>().As<IGamePlayBusiness>();
            _builder.RegisterType<GameBusiness>().As<IGameBusiness>();

            //Mappers Controller - Business
            _builder.RegisterType<RotationModelMapper>().As<IRotationModelMapper>();
            _builder.RegisterType<GamePlayModelMapper>().As<IGamePlayModelMapper>();

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