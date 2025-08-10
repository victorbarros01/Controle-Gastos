namespace ProjetoAspNet.Service {
    public static class VerifyEmailService {
        public static bool VerifyEmail(int emailCode, int code) {
            if (emailCode == code) {
                return true;
            } else {
                return false;
            }
        }
    }
}
