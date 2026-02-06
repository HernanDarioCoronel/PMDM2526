package ies.murallaromana.apiconnection.model

data class Personaje(
    val id: Int,
    val nombre: String,
    val casa: String,
    val imageUrl: String
)

val listaPersonajes = listOf(
    Personaje(
        id = 1,
        nombre = "Jon Snow",
        casa = "Stark",
        imageUrl = "https://upload.wikimedia.org/wikipedia/en/3/30/Jon_Snow_Season_8.png"
    ),
    Personaje(
        id = 2,
        nombre = "Daenerys Targaryen",
        casa = "Targaryen",
        imageUrl = "https://static.wikia.nocookie.net/hieloyfuego/images/2/2f/Daenerys_Targaryen_Queen.png/revision/latest?cb=20241023160006"
    ),
    Personaje(
        id = 3,
        nombre = "Tyrion Lannister",
        casa = "Lannister",
        imageUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/Tyrion_Lannister-Peter_Dinklage.jpg"
    ),
    Personaje(
        id = 4,
        nombre = "Arya Stark",
        casa = "Stark",
        imageUrl = "https://static.wikia.nocookie.net/gameofthrones/images/b/be/AryaShipIronThrone.PNG/revision/latest?cb=20190520174300"
    ),
    Personaje(
        id = 5,
        nombre = "Sansa Stark",
        casa = "Stark",
        imageUrl = "https://static.wikia.nocookie.net/gameofthrones/images/6/63/QueenSansa.PNG/revision/latest?cb=20210215100224"
    )
)