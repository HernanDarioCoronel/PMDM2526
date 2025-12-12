package es.murallaromana.testcompose.ui.theme.screens

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.foundation.text.KeyboardActions
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material3.Button
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import es.murallaromana.testcompose.R

@Preview
@Composable
fun LoginScreen(modifier: Modifier = Modifier) {
    var contrasenha by rememberSaveable() { mutableStateOf("******") }
    var email by rememberSaveable() { mutableStateOf("email@gmail.com") }
    Column(modifier = Modifier.background(Color.White)) {
        Box(
            modifier = Modifier
                .fillMaxWidth(),
            contentAlignment = Alignment.Center,

            ) {
            Image(
                painter = painterResource(id = R.drawable.icons8_lock),
                contentDescription = "login logo",
                modifier = Modifier
                    .size(120.dp)
                    .clip(CircleShape)
                    .background(Color.Green)
                    .padding(15.dp),
            )
        }
        Text(
            text = "Bienvenido", modifier = Modifier
                .fillMaxWidth(),
            fontWeight = FontWeight.Bold, fontSize = 28.sp, textAlign = TextAlign.Center
        )
        Text(
            text = "Inicia Sesión para continuar", modifier = Modifier
                .fillMaxWidth(),
            fontSize = 20.sp, textAlign = TextAlign.Center
        )
        OutlinedTextField(
            modifier = Modifier.fillMaxWidth(),
            value = email,
            onValueChange = {
                email = it
            },
            leadingIcon = {
                Image(
                    modifier = Modifier.size(15.dp),
                    painter = painterResource(id = R.drawable.icons8_mail_96),
                    contentDescription = "img_correo"
                )
            },
            label = { Text("Correo Electrónico") },
            keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password),

            )
        OutlinedTextField(
            modifier = Modifier.fillMaxWidth(),
            value = contrasenha,
            onValueChange = {
                contrasenha = it
            },
            label = { Text("Contraseña") },
            keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password),
        )
        Text(
            modifier = Modifier
                .clickable {}
                .fillMaxWidth(),
            color = Color.Green,
            text = "¿Olvidaste tu contraseña?",
            textAlign = TextAlign.Right
        )
        Button(
            onClick = {},
            modifier = Modifier
        ) {
            Text("inicia sesión")
        }
    }
}