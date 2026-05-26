using System;
using System.Windows.Forms;
using HiwleawHubShared; // เรียกใช้โมเดล

namespace HiwleawHubAdminApp
{
    public partial class ReviewCardControl : UserControl
    {
        // เก็บข้อมูลรีวิวไว้ในตัวแปรนี้
        public Review CurrentReview { get; private set; }

        // สร้างช่องทางส่งสัญญาณไปบอกหน้าหลักเวลาโดนกดลบ
        public event EventHandler OnDeleteClicked;

        public ReviewCardControl()
        {
            InitializeComponent();
        }

        // ฟังก์ชันรับข้อมูลจาก Database มาแปะบนหน้าจอ
        public void SetReviewData(Review review)
        {
            CurrentReview = review;

            // 1. ใส่ตัวหนังสือ
            lblReviewerName.Text = string.IsNullOrEmpty(review.ReviewerName) ? "ไม่ระบุชื่อ" : review.ReviewerName;
            // เช็คว่าถ้ามีชื่อเมนูส่งมาให้โชว์ชื่อเมนู แต่ถ้าไม่มีก็โชว์รหัสเผื่อเหนียวไว้ก่อน
            lblMenuName.Text = string.IsNullOrEmpty(review.MenuName) ? $"รหัสเมนู: {review.MenuId}" : review.MenuName;
            lblComment.Text = string.IsNullOrEmpty(review.Comment) ? "ไม่มีข้อความรีวิว" : review.Comment;

            // 2. เสกดาว ⭐ ตามคะแนน (1-5)
            lblRating.Text = new string('★', review.Rating) + new string('☆', 5 - review.Rating);
        }

        // เมื่อปุ่มลบถูกกด
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ส่งสัญญาณไปบอกฟอร์มหลักให้รู้ว่ามีการกดลบการ์ดใบนี้
            OnDeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }
    }
}