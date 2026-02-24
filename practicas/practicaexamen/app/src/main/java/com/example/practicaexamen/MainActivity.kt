package com.example.practicaexamen

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.navigation3.runtime.NavEntry
import androidx.navigation3.ui.NavDisplay
import com.example.practicaexamen.screens.ListaCoches
import com.example.practicaexamen.screens.Login
import com.example.practicaexamen.screens.OtraVista
import com.example.practicaexamen.ui.theme.PracticaExamenTheme

data object LoginRoute
data object ListaCochesRoute
data object OtraVistaRoute

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            var backStack = remember { mutableStateListOf<Any>(ListaCochesRoute) }

            PracticaExamenTheme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    NavDisplay(
                        modifier = Modifier.padding(innerPadding),
                        backStack = backStack,
                        onBack = {backStack.removeLastOrNull()},
                        entryProvider = {key ->
                            when (key){
                                is LoginRoute -> NavEntry(key){
                                    Login(
                                        navigateToCochesList = { backStack.add(ListaCochesRoute) },
                                        navigateToOther = {backStack.add(OtraVistaRoute)}
                                    )
                                }
                                is ListaCochesRoute -> NavEntry(key){
                                    ListaCoches(backStack)
                                }
                                is OtraVistaRoute -> NavEntry(key){
                                    OtraVista(backStack)
                                }
                                else -> NavEntry(Unit){Text("Ruta desconocida")}
                            }
                        }
                    )
                }
            }
        }
    }
}
