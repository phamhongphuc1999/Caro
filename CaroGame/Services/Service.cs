// ---------------CARO GAME---------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ----------------------------------------

using CaroGame.Services.Services;

namespace CaroGame.Services
{
    public class Service
    {
        public ActionService Action;
        public BoardService Board;
        public LanguageService Language;
        public PlayerService Player;
        public SoundService Sound;
        public StorageService Storage;
        public TimerService Timer;
        public WinnerService Winner;

        public Service()
        {
            Action = new ActionService();
            Board = new BoardService();
            Language = new LanguageService();
            Player = new PlayerService();
            Sound = new SoundService();
            Storage = new StorageService();
            Timer = new TimerService();
            Winner = new WinnerService();
        }
    }
}
