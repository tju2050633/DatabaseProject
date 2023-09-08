namespace Garden.Models
{
    public class RecruitInfo
    {

        // imageUrl: require("../assets/Garden-e.jpg"), // 根据需要设置正确的路径
        // dialogVisible: false,
        // username: "Student1",
        // gardenname: "王浩的后宫1",
        // location: "嘉定校区19号楼",
        // describe: volunteer.description,
        public string imageUrl { get; set; }
        public string username { get; set; }
        public string gardenname { get; set; }
        public string location { get; set; }
        public string? describe { get; set; }
    }
}
