import android.content.ClipData
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material3.Card
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Icon
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TopAppBar
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.text.font.FontWeight
import androidx.navigation3.runtime.NavKey
import coil.compose.AsyncImage
import ies.murallaromana.apiconnection.model.Personaje
import ies.murallaromana.apiconnection.model.listaPersonajes
import kotlinx.serialization.Serializable

@Serializable
data object ListaPersonajes : NavKey

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun ListaPersonajesScreen() {
    Scaffold(
        topBar = {
            TopAppBar(
                title = { Text("Personajes de la serie") }
            )
        }
    ) { innerPadding ->
        LazyColumn(modifier = Modifier.padding(innerPadding)) {
            items(listaPersonajes) { personaje ->
                PersonajeItem(personaje)
            }
        }
    }
}

@Composable
fun PersonajeItem(personaje: Personaje) {
    Card(onClick = {}) {
        Box(modifier = Modifier.clip(CircleShape)) {
            AsyncImage(
                model = personaje.imageUrl,
                contentDescription = personaje.nombre,

                )
        }
        Column {
            Text(fontWeight = FontWeight.Bold, text = personaje.nombre)
            Text(personaje.casa)
        }
    }
}