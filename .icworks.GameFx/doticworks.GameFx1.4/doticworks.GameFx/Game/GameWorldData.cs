namespace doticworks.GameFx.Game
{
    public partial class GameWorld
    {
        private bool isworking = false;
        
        
        #region Debugs
        public bool DebugMode = true;
        public float DeltaTime = 0.025f;
        public long TickInput;
        public long TickUpdate;
        public long TickPresent;
        #endregion
        
    }
}