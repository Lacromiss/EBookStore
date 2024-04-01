using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Services.Exceptions;
using Services.Interfaces;
using Services.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IWebHostEnvironment _env;

        public BlogService(IBlogRepository blogRepository,IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _env=env;
        }

        public async Task CreateAsync(Blog blog)
        {
            try
            {
                if (blog.Photo != null)
                {


                    if (!blog.Photo.CheckType("image/"))
                    {
                        throw new ImgValidationExcemtions("img formatinda bir seyler at");

                    }
                    if (!blog.Photo.CheckSize(5))
                    {
                        throw new ImgValidationExcemtions("maks 5mbfayl yukelye bilersen");

                    }
                    blog.ImgUrl = await blog.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Assests", "assets", "img"));
                    blog.CreatedDate = DateTime.Now;
                    await _blogRepository.AddAsync(blog);
                }

            }
            catch (ImgValidationExcemtions ex)
            {

                throw ex;
            }
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(id);

        }

        public async Task UpdateAsync(Blog blog, int id)
        {


            try
            {
                Blog blog1 = await _blogRepository.GetByIdAsync(id);

                if (blog1 == null)
                {
                    throw new ImgValidationExcemtions("axtarilan id ye uyqun melumat tapilmadi");
                }



                if (!blog.Photo.CheckType("image/"))
                {
                    throw new ImgValidationExcemtions("img formatinda bir seyler at");

                }
                if (!blog.Photo.CheckSize(5))
                {
                    throw new ImgValidationExcemtions("maks 5mbfayl yukelye bilersen");

                }

                blog1.Title = blog.Title;
                blog1.Description = blog.Description;
                blog1.Author = blog.Author;
                blog1.AuthorId = blog1.AuthorId;
                blog1.ImgUrl = blog.ImgUrl;
                blog1.isDeleted = blog.isDeleted;
                blog1.UpdatedDate = DateTime.Now;
                blog1.CreatedDate = blog.CreatedDate;

                blog1.Link = blog.Link;
                blog1.isFeatured = blog.isFeatured;


                await _blogRepository.UpdateAsync(blog1);
                if (blog1.ImgUrl != null)
                {
                    string existPhoto = Path.Combine(_env.WebRootPath, "Assests", "assets", "img", blog1.ImgUrl);
                    if (System.IO.File.Exists(existPhoto))
                    {
                        System.IO.File.Delete(existPhoto);

                    }

                }
                blog1.ImgUrl = await blog.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Assests", "assets", "img"));


                await _blogRepository.UpdateAsync(blog1);

            }
            catch (ImgValidationExcemtions ex)
            {

                throw ex;
            }











        }
        public async Task RemoveAasync(int id)
        {
            Blog book = await _blogRepository.GetByIdAsync(id);
            try
            {
                if (book != null)
                {
                    if (book.ImgUrl != null)
                    {
                        string existPhoto = Path.Combine(_env.WebRootPath, "Assests", "assets", "img", book.ImgUrl);
                        if (System.IO.File.Exists(existPhoto))
                        {
                            System.IO.File.Delete(existPhoto);

                        }

                    }

                    await _blogRepository.RemoveAsync(book);
                }
                else
                {
                    throw new ImgValidationExcemtions("NOT found");
                }

            }
            catch (ImgValidationExcemtions)
            {

                throw new ImgValidationExcemtions("not removed");
            }


        }
    }

    }
