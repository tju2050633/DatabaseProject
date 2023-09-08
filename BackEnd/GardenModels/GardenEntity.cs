namespace Garden.Models
{
    public class GardenEntity
    {
        public string GardenId { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string? Pictures { get; set; }
        public DateTime CreateTime { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public int Stars { get; set; } = 0;
        public int Status { get; set; } = 1; // [0:"Approved", 1:"Waiting", 2:"Rejected"]
    }

    // 简易版Garden，用于返回个人主页前端和搜索结果，只显示用户名、标题、花园ID、Star数、（封面）
    public class GardenInfo
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string? Cover { get; set; }
        public string GardenId { get; set; }
        public int Stars { get; set; }
    }

    // 花园评论历史记录，用于返回前端
    public class GardenCommentInfo
    {
        public string Author { get; set; }  // 花园主人用户名
        public string Title { get; set; }   // 花园标题
        public string? Avatar { get; set; } // 花园主人头像
        public string GardenId { get; set; }
        public int Stars { get; set; }
        public string? Imageurl { get; set; } // Cover
        public string Comment { get; set; }  // 评论内容 
        public DateTime CommentTime { get; set; }
    }

    // 花园点赞历史记录，用于返回前端
    public class GardenLikeInfo
    {
        public string Author { get; set; }  // 花园主人用户名
        public string Title { get; set; }   // 花园标题
        public string? Avatar { get; set; } // 花园主人头像
        public string GardenId { get; set; }
        public int Stars { get; set; }
        public string? Imageurl { get; set; } // Cover
        public DateTime? LikeTime { get; set; }
    }

}

