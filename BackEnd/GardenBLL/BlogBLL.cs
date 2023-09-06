﻿using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class BlogBLL : IBlogBLL
    {
        AccountDAL accountDAL = new();
        BlogDAL blogDAL = new();
        BlogCommentsDAL blogcommentsDAL = new();

        public Blog GetSingleBlog(string id)
        {
            return blogDAL.GetBlogById(id, out _);
        }

        public Blog GetBlogRandomly()
        {
            return blogDAL.GetBlogRandomly();
        }

        public List<Blog> GetUserBlogs(string id)
        {
            return blogDAL.GetBlogByOwnerId(id, out _);
        }

        public string Insert(Blog blog)
        {
            if (blogDAL.Insert(blog, out _))
            {
                return "上传成功，等待审核。";
            }
            else
            {
                return "上传失败，请重试。";
            }
        }

        //public string Update(Blog blog)
        //{
        //    return "";
        //}

        public string Delete(string id)
        {
            if (blogDAL.Delete(id, out _))
            {
                return "删除成功。";
            }
            else
            {
                return "删除失败。";
            }
        }


        public List<BlogComments> GetComments(string blog_id)
        {
            return blogcommentsDAL.GetCommentsById(blog_id, out _);
        }

        public string Insert_Comments(string owner_id, string blog_id, string content)
        {
            BlogComments blogcomments_info = new()
            {
                OwnerId = owner_id,
                BlogId = blog_id,
                ReleaseTime = DateTime.Now,
                Content = content
            };

            bool Ins = blogcommentsDAL.Insert_Comment(blogcomments_info);
            if (Ins)
            {
                return "评论发布成功";
            }
            else
            {
                return "评论发布失败，请重试";
            }
        }

        public List<Blog> GetMoreBlogs(int startIndex, int num)
        {
            return blogDAL.GetMoreBlogs(startIndex, num);
        }

        public string PutAgreeNum(int agreeNum, string blog_id)
        {
            return blogDAL.PutAgreeNum(agreeNum, blog_id);
        }

        public int AddAgree(string blog_id, int num = 1)
        {
            return blogDAL.AddAgree(blog_id, num);
        }
    }
}
