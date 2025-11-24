package es.murallaromana.segunda.login

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class RegisterActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_register)

        val intent = intent
        val emailCt: EditText = findViewById(R.id.emailCt)
        val email = intent.getStringExtra("email")
        if (email != null) {
            emailCt.setText(email)
        }

        val psw1: EditText = findViewById(R.id.passwordCt)
        val psw2: EditText = findViewById(R.id.reenterPaswordCt)
        val registerBtn = findViewById<Button>(R.id.singInBtn)

        registerBtn.setOnClickListener {
            var text = "";
            if (psw2.text.toString() != psw1.text.toString()) {
                text = "Esta mal la  pass, mogo"
            } else {
                val nombreCt: EditText = findViewById(R.id.nameCt)
                text = "Bienvenido " + nombreCt.text + ".!!!"
            }
            Toast.makeText(this, text, Toast.LENGTH_LONG).show()
        }
    }
}