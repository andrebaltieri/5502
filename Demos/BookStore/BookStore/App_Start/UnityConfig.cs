using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using BookStore.Repositories.Contracts;
using BookStore.Repositories;
using BookStore.Context;

namespace BookStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<BookStoreDataContext, BookStoreDataContext>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}