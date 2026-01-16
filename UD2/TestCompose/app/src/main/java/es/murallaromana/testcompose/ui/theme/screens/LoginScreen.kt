package es.murallaromana.testcompose.ui.theme.screens

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.HorizontalDivider
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.OutlinedTextFieldDefaults
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TextFieldColors
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.ColorFilter
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import es.murallaromana.testcompose.R
import es.murallaromana.testcompose.ui.theme.components.MiTopBar

@Preview
@Composable
fun LoginScreen(modifier: Modifier = Modifier) {
    val verdePpal = Color(0xFF00C24D)
    val grisAux = Color(0xFFC0C0C0)
    val grisTexto = Color(0xFF2D3948)
    var contrasenha by rememberSaveable() { mutableStateOf("******") }
    var email by rememberSaveable() { mutableStateOf("email@gmail.com") }

    Column(modifier = Modifier.background(Color.White)) {
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(top = 40.dp),
            horizontalArrangement = Arrangement.Center
        ) {
            Box(
                modifier = Modifier
                    .padding(40.dp)
                    .clip(CircleShape)
                    .background(verdePpal)
                    .padding(15.dp),
                contentAlignment = Alignment.Center,
            ) {
                Image(
                    painter = painterResource(id = R.drawable.icons8_lock),
                    contentDescription = "login logo",
                    modifier = Modifier
                        .size(70.dp),
                    colorFilter = ColorFilter.tint(Color.White)
                )
            }
        }
        Text(
            color = grisTexto,
            text = "Bienvenido",
            modifier = Modifier
                .fillMaxWidth()
                .padding(vertical = 15.dp),
            fontSize = 28.sp,
            textAlign = TextAlign.Center
        )
        Text(
            color = grisTexto,
            text = "Inicia Sesión para continuar", modifier = Modifier
                .fillMaxWidth()
                .padding(bottom = 30.dp),
            fontSize = 20.sp, textAlign = TextAlign.Center,
            fontWeight = FontWeight.Light
        )
        Text(
            text = "Correo Electrónico",
            modifier = Modifier.padding(start = 15.dp),
            color = grisTexto
        )
        OutlinedTextField(
            modifier = Modifier
                .fillMaxWidth()
                .padding(15.dp),
            value = email,
            onValueChange = {
                email = it
            },
            leadingIcon = {
                Image(
                    colorFilter = ColorFilter.tint(grisTexto),
                    modifier = Modifier.size(15.dp),
                    painter = painterResource(id = R.drawable.icons8_mail_96),
                    contentDescription = "img_correo"
                )
            },
            keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password),
            colors = OutlinedTextFieldDefaults.colors(focusedBorderColor = verdePpal)
            )

        Text(
            text = "Contraseña",
            modifier = Modifier.padding(start = 15.dp),
            color = grisTexto
        )
        OutlinedTextField(
            modifier = Modifier
                .fillMaxWidth()
                .padding(15.dp),
            value = contrasenha,
            onValueChange = {
                contrasenha = it
            },
            leadingIcon = {
                Image(
                    modifier = Modifier.size(15.dp),
                    painter = painterResource(id = R.drawable.icons8_lock),
                    contentDescription = "img_correo"
                )
            },
            trailingIcon = {
                Button(
                    onClick = {},
                    colors = ButtonDefaults.buttonColors(Color.Transparent)
                ) {
                    Image(
                        modifier = Modifier.size(15.dp),
                        painter = painterResource(id = R.drawable.icons8_eye_24),
                        contentDescription = "img_correo"
                    )
                }
            },
            keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password),
        )
        Text(
            modifier = Modifier
                .clickable {}
                .fillMaxWidth()
                .padding(end = 15.dp),
            color = verdePpal,
            text = "¿Olvidaste tu contraseña?",
            textAlign = TextAlign.Right
        )
        Row(modifier = Modifier.padding(20.dp)) {
            Button(
                onClick = {},
                modifier = Modifier
                    .height(60.dp)
                    .fillMaxWidth(),
                colors = ButtonDefaults.buttonColors(containerColor = verdePpal),
                shape = RoundedCornerShape(8.dp)
            ) {
                Text(
                    text = "INICIAR SESIÓN",
                    fontSize = 20.sp,
                    fontWeight = FontWeight.Light
                )
            }
        }
        Row(
            verticalAlignment = Alignment.CenterVertically,
            modifier = Modifier
                .fillMaxWidth()
                .padding(vertical = 20.dp, horizontal = 5.dp)
        ) {
            Column(Modifier.weight(8f)) {
                HorizontalDivider(
                    thickness = 1.dp,
                    color = grisAux
                )
            }
            Column(Modifier.weight(2f)) {
                Text(
                    text = "o",
                    textAlign = TextAlign.Center,
                    color = grisAux,
                    fontSize = 20.sp,
                    modifier = Modifier.fillMaxWidth()
                )
            }
            Column(Modifier.weight(8f)) {
                HorizontalDivider(
                    thickness = 1.dp,
                    color = grisAux
                )
            }
        }
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(vertical = 40.dp),
            horizontalArrangement = Arrangement.Center
        ) {
            Text(text = "¿No tienes cuenta?. ", color = grisTexto)
            Text(
                modifier = Modifier
                    .clickable {},
                color = verdePpal,
                text = "Regístrate",
            )
        }
    }
}