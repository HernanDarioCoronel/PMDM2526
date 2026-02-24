package com.example.practica2

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.Column
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
import com.example.practica2.ui.theme.Practica2Theme

class MainActivity : ComponentActivity() {
    data object op1Route
    data object op2Route

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            var backstack = remember { mutableStateListOf<Any>(op1Route) }
            Practica2Theme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    NavDisplay(
                        modifier = Modifier.padding(innerPadding),
                        onBack = { backstack.removeLastOrNull() },
                        backStack = backstack,
                        entryProvider = { key ->
                            when (key) {
                                is op1Route -> NavEntry(key) {
                                    Op1(navigateToop2 = { backstack.add(op2Route) })
                                }

                                is op2Route -> NavEntry(key) {
                                    Op2(navigateToop1 = { backstack.add(op1Route) })
                                }

                                else -> NavEntry(Unit) { Text("Not found") }
                            }
                        }
                    )
                }
            }
        }
    }
}
