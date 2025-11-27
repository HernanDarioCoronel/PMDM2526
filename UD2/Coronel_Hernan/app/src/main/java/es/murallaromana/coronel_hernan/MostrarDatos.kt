package es.murallaromana.coronel_hernan

import android.annotation.SuppressLint
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.google.android.material.snackbar.BaseTransientBottomBar
import kotlin.time.Duration

class MostrarDatos : AppCompatActivity() {
    @SuppressLint("SetTextI18n")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_mostrar_datos)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        val nome = intent.getStringExtra("nome")
        val apel = intent.getStringExtra("apelido")

        val personaLb: TextView = findViewById(R.id.personaLb)
        personaLb.text = "$nome $apel"

        val ciclosBt: Button = findViewById(R.id.ciclosBt)

        ciclosBt.setOnClickListener {
            Toast.makeText(this, "No implementado todavía", Toast.LENGTH_LONG).show()
        }

        var contador = 0

        val seguridadBt: Button = findViewById(R.id.seguridadBt)
        seguridadBt.setOnClickListener {
            if (contador >= 2)
                seguridadBt.isEnabled = false
            else
                contador++
        }

    }
}