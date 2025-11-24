package es.murallaromana.segunda.login

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class Login : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        val testUser = "test@text.com"
        val textpassw = "abc123."

        val userInput: EditText = findViewById(R.id.userCt)
        val passwInput: EditText = findViewById(R.id.pswCt)
        val loginBtn: Button = findViewById(R.id.loginBtn)
        loginBtn.setOnClickListener {
            if (userInput.text.length > 1 && passwInput.text.length > 1) {
                if (userInput.text.toString() == testUser || passwInput.text.toString() == textpassw) {

                }
                Toast.makeText(
                    this,
                    "Registro Exitoso. bienvenido " + userInput.text,
                    Toast.LENGTH_LONG
                ).show()
            } else {
                Toast.makeText(
                    this,
                    "Registro incorrecto",
                    Toast.LENGTH_LONG
                ).show()
            }
        }
        val registerBtn: Button = findViewById(R.id.registerBtn)
        registerBtn.setOnClickListener {
            val goToRegisterView = Intent(this, RegisterActivity::class.java)
            if (userInput.text.length > 1) {
                goToRegisterView.putExtra("email", userInput.text.toString())
            }
            startActivity(goToRegisterView)
        }
    }
}