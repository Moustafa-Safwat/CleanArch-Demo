﻿namespace CleanArchDemo.Application.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; } = [];
    }
}
