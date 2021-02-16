using MyAliSite.Services.Interfaces;
using MyDataFX;
using MyDataFX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAliSite.Services
{
    public class TestService : ITestService
    {
        public IRepository<BlogContent> BlogContentRepository { get; set; }

        public string GetHello()
        {
            var list = BlogContentRepository.GetList();
            return "Hello";
        }
    }
}