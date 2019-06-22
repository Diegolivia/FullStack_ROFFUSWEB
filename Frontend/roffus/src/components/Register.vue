<template>
  <v-app id="inspire" dark>
    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <v-flex xs12 sm8 md4>
            <v-card class="elevation-12">
              <v-toolbar dark color="green">
                <v-toolbar-title>Register form</v-toolbar-title>
                <v-spacer></v-spacer>
                    <v-btn fab small dark to="/layout">
                        <v-icon>close</v-icon>
                    </v-btn>
              </v-toolbar>
                <div>
                    <v-alert :value="true" type="info">
                        Por favor poner todos sus datos correctamente.
                        </v-alert>
                </div>
              <v-card-text>
                <v-form>
                  <v-text-field prepend-icon="person" name="register" label="register" type="text"></v-text-field>
                  <v-text-field prepend-icon="correo" name="correo" label="correo" type="text"></v-text-field>
                  <v-text-field id="password" prepend-icon="lock" name="password" label="Password" type="password"></v-text-field>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn dark color= "green" >Register</v-btn>
                //
                    <div class="text-xs-center">
                        <v-dialog v-model="dialog" width="500">
                            <template v-slot:activator="{ on }">
                                <v-btn color="red lighten-2" dark v-on="on">
                                    Más info
                                </v-btn>
                            </template>
                            <v-card>
                                <v-card-title class="headline grey lighten-2" primary-title >
                                    Politica del Sitio
                                </v-card-title>
                                
                            <v-card-text>
                                Roffus usa la base de datos de diferentes empresas para la recolección de información de los muebles y utiliza un plano 2d, si no tienes problemas con eso presiona el botón "Seguir" .
                            </v-card-text>
                                <v-divider></v-divider>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="primary" flat @click="dialog = false">
                                        Seguir
                                    </v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </div>
                //
              </v-card-actions>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>
      //
      <v-footer class="pa-3">
        <v-spacer></v-spacer>
        <div>&copy; {{ new Date().getFullYear() }}</div>
      </v-footer>
      //
    </v-content>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      drawer: null
    }),
    props: {
      source: String
    }
  }
  //El de abajo es para el botón-dialogo
  export default {
    data () {
      return {
        dialog: false
      }
    }
  }

</script>