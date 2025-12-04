fun main() {
    val p1 = Persona("Hernan", "Coronel", 29, 600.00)

    val listaPersonas = listOf(
        p1,
        p1.copy(nombre = "Martin", salario = 200.00),
        p1.copy(nombre = "Sabrina", salario = 1500.00),
        p1.copy(nombre = "Scarlet", edad = 10)
    )

    listaPersonas.filter { it.edad > 18 }
        .forEach { println(it) }

    val listaConSalariosDuplicados = listaPersonas
        .map {
            if (it.nombre[0].lowercase() == "m")
                it.copy(salario = it.salario * 2)
            else
                it
        }
    listaConSalariosDuplicados
        .forEach { print(it) }

    println(
        "Total salarios: " +
                listaConSalariosDuplicados
                    .reduce { acum, item -> acum.copy(salario = acum.salario + item.salario) }
                    .salario
    )

    println(
        "Total de mayores de 25: " +
                listaConSalariosDuplicados
                    .filter { it.edad > 25 }
                    .map { it.salario }
                    .average()
    )
}

data class Persona(val nombre: String, val apellidos: String, val edad: Int, val salario: Double)