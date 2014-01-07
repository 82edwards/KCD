using KcdModel.Discussions;

namespace KCD.ViewModel
{
    public class ViewATopic
    {
        #region Properties
        public Topic Topic { get; set; }
        #endregion

        public ViewATopic(int topicId)
        {
            Topic = Topic.GetTopic(topicId);
        }
    }
}