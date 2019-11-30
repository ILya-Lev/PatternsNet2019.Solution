namespace Creational.BuilderSmartHouse
{
    internal interface IPost
    {
        string DoPost();
    }

    internal class Post : IPost
    {
        public string DoPost() => "I'm a post";
    }
}
