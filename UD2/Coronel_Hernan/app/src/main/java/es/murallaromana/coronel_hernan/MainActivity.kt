package es.murallaromana.coronel_hernan

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.google.android.material.textfield.TextInputEditText
import com.google.android.material.textfield.TextInputLayout

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val enviarBt: Button = findViewById(R.id.enviarBt)
        val nomeCt: TextView = findViewById(R.id.nomeCt)
        val apelidoCt: TextView = findViewById(R.id.apelidoCt)


        enviarBt.setOnClickListener {
            var error = false
            if (nomeCt.text.toString().length < 1){
                nomeCt.setError("Campo Requerido")
                error = true
            }
            if (nomeCt.text.toString().length < 1){
                nomeCt.setError("Campo Requerido")
                error = true
            }

            val intent = Intent(this, MostrarDatos::class.java)

            intent.putExtra("nome", nomeCt.text.toString())
            intent.putExtra("apelido", apelidoCt.text.toString())

            startActivity(intent)
        }
    }
}