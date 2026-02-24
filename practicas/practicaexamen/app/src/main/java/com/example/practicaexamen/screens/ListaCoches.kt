package com.example.practicaexamen.screens

import android.text.Layout
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.Card
import androidx.compose.material3.CardDefaults
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.compose.ui.res.vectorResource
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import com.example.practicaexamen.R

@Composable
fun ListaCoches(backstack: MutableList<Any>) {
    Column() {
        LazyColumn() {
            items(coches) { coche ->
                Card(
                    modifier = Modifier
                        .fillMaxWidth()
                        .padding(5.dp)
                        .background(MaterialTheme.colorScheme.secondaryContainer)
                        .padding(5.dp),
                    elevation = CardDefaults.cardElevation(pressedElevation = 5.dp)
                ) {
                    Row(
                        horizontalArrangement = Arrangement.SpaceBetween,
                        modifier = Modifier
                            .fillMaxWidth()
                    ) {
                        Row (verticalAlignment = Alignment.CenterVertically) {
                            Image(
                                imageVector = ImageVector.vectorResource(R.drawable.coche),
                                contentDescription = "agshseytd",
                                modifier = Modifier.padding(5.dp)
                            )
                            Column() {
                                Text("Marca: ${coche.marca}")
                                Text("Modelo: ${coche.modelo}")
                            }
                        }
                        Column() {
                            Text("Año: ${coche.anho}", textAlign = TextAlign.End)
                            Text("Precio: ${coche.precio} €", textAlign = TextAlign.End)
                        }
                    }
                }
            }
        }
    }
}

data class Coche(
    val marca: String,
    val modelo: String,
    val anho: Int,
    val precio: Float
)

val coches = listOf(
    Coche("Toyota", "Corolla", 2023, 25500.0f),
    Coche("Tesla", "Model 3", 2024, 39990.0f),
    Coche("Porsche", "911 Carrera", 2022, 115000.0f),
    Coche("Ford", "Mustang Mach-E", 2023, 45000.5f),
    Coche("Hyundai", "Ioniq 5", 2024, 42000.0f),
    Coche("Mazda", "MX-5 Miata", 2021, 28000.0f),
    Coche("Volkswagen", "Golf GTI", 2023, 32500.9f),
    Coche("Audi", "RS6 Avant", 2024, 125900.0f),
    Coche("Honda", "Civic Type R", 2023, 44800.0f),
    Coche("BMW", "M3", 2024, 76000.0f)
)
