using System.Windows.Forms;
using HiwleawHubShared;

namespace HiwleawHubCustomerApp
{
    public partial class CustomerReviewCardControl : UserControl
    {
        public CustomerReviewCardControl() => InitializeComponent();

        public void SetReviewData(Review review)
        {
            lblReviewer.Text = review.ReviewerName;
            lblComment.Text = review.Comment;
            lblStars.Text = new string('⭐', review.Rating);
        }
    }
}