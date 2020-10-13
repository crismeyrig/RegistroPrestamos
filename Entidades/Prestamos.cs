using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrestamos.Entidades
{

public class Prestamos{
[Key]
public int PrestamoId {get; set;} =0;

public DateTime Fecha {get; set;} =DateTime.Now;

public int PersonaId {get; set;}

public string Concepto {get; set;}

public int Monto {get; set;}

public int Balance {get; set;}

}
}