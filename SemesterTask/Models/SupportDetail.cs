namespace SemesterTask.Models
{
    public class SupportDetail
    {
        public int SupportPercent { get; set; }
        public string PartyName { get; set; }

        public override bool Equals(object obj)
        {
            var supportDetail = obj as SupportDetail;

            return supportDetail.PartyName.Equals(this.PartyName) && supportDetail.SupportPercent == this.SupportPercent;
        }

        public override int GetHashCode()
        {
            return SupportPercent.GetHashCode() ^ PartyName.GetHashCode();
        }
    }
}
