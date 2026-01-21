package es.murallaromana.testcompose2

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material3.Button
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation3.runtime.NavBackStack
import androidx.navigation3.runtime.NavEntry
import androidx.navigation3.ui.NavDisplay
import es.murallaromana.testcompose2.ui.nav.PrimeraPantalla
import es.murallaromana.testcompose2.ui.nav.SegundaPantalla
import es.murallaromana.testcompose2.ui.screens.MiPrimeraPantalla
import es.murallaromana.testcompose2.ui.screens.MiSegundaPantalla
import es.murallaromana.testcompose2.ui.theme.TestCompose2Theme


class MainActivityBasico : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            TestCompose2Theme {

                val backStack = remember {
                    mutableStateListOf<Any>(PrimeraPantalla)
                }

                NavDisplay(
                    backStack = backStack,
                    onBack = { backStack.removeAt(backStack.lastIndex) },
                    entryProvider = { clave ->
                        when (clave) {
                            PrimeraPantalla -> NavEntry(PrimeraPantalla) {
                                MiPrimeraPantalla(){
                                    backStack.add(SegundaPantalla)
                                }
                            }

                            SegundaPantalla -> NavEntry(SegundaPantalla) {
                                MiSegundaPantalla() {
                                    backStack.add(PrimeraPantalla)
                                }
                            }

                            else -> NavEntry(Unit) {}
                        }
                    }
                )
                /*
                Scaffold(
                    modifier = Modifier.fillMaxSize(),
                    containerColor = Color.LightGray,
                    topBar = { MiTopBar(modifier = Modifier) }

                ) { innerPadding ->
                    MisTextField(modifier = Modifier.padding(innerPadding))
                }
                */
            }
        }
    }
}
