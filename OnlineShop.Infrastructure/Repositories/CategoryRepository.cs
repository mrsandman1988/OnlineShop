﻿using OnlineShop.Core.Entities;
using OnlineShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace OnlineShop.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineShopDbContext _context;
        public CategoryRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void AttachRange(List<Category> categories)
        {
           _context.Categories.AttachRange(categories);
        }

        public void Delete(Category category)
        {
           _context.Categories.Remove(category);
        }

        public List<Category> GetAll()
        {
           return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void ChengeTracking(Category category)
        {
            _context.Entry(category).State = EntityState.Detached;
        }
    }
}
