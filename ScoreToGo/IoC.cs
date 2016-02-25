﻿using Autofac;
using ScoreToGo.Controllers;
using ScoreToGo.Mappers;
using ScoreToGo.Mappers.Interfaces;
using STGBusiness.Logic;
using STGBusiness.Logic.Interfaces;
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

            //Business
            _builder.RegisterType<RotationBusiness>().As<IRotationBusiness>();

            //Controllers
            _builder.RegisterType<HomeController>();
            _builder.RegisterType<RotationController>();
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