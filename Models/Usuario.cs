﻿using System;
using System.Collections.Generic;

namespace ApiRestFull.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Cedula { get; set; }
}
