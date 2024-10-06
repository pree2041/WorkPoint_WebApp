﻿namespace WorkPoint_WebApp.Shared.Parameters
{
    public class NewsParameters
    {
        public int PageNumber { get; set; } = 1; 

        private int _pageSize = 10; 
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 100) ? 100 : (value < 1 ? 1 : value); 
        }
    }
}
