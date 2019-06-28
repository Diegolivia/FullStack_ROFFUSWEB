<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Usuarios</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          single-line
          hide-details
        ></v-text-field>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nombreUsuario" label="NombreUsuario"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="correo" label="Correo"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="contraseña" label="Contraseña"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="fNacimiento" label="FNacimiento"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="foto" label="Foto"></v-text-field>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="usuarios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.nombreUsuario }}</td>
          <td>{{ props.item.correo }}</td>
          <td>{{ props.item.contraseña }}</td>
          <td>{{ props.item.fNacimiento }}</td>
          <td>{{ props.item.foto }}</td>
        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      usuarios: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "NombreUsuario", value: "nombreUsuario", sortable: false },
        { text: "Correo", value: "correo", sortable: false },
        { text: "Contraseña", value: "contraseña" },
        { text: "FNacimiento", value: "fNacimiento" },
        { text: "Foto", value: "foto" }
      ],
      search: "",
      editedIndex: -1,

      //Model
      codUsuario: "",
      nombreUsuario: "",
      correo: "",
      contraseña: "",
      fNacimiento: "",
      foto: ""
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Usuario" : "Actualizar Usuario";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/usuario")
        .then(function(response) {
          //console.log(response);
          me.usuarios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      this.codUsuario = item.codUsuario;
      this.nombreUsuario = item.nombreUsuario;
      this.correo = item.correo;
      this.contraseña = item.contraseña;
      this.fNacimiento = item.fNacimiento;
      this.foto = item.foto;

      this.editedIndex = 1;
      this.dialog = true;
    },

  

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.codUsuario = "";
      this.nombreUsuario = "";
      this.correo = "";
      this.contraseña = "";
      this.fNacimiento = "";
      this.foto = "";
    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/usuario", {
            codUsuario: me.codUsuario,
            nombreUsuario: me.nombreUsuario,
            correo: me.correo,
            contraseña: me.contraseña,
            fNacimiento: me.fNacimiento,
            foto: me.foto
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/usuario", {
            nombreUsuario: me.nombreUsuario,
            correo: me.correo,
            contraseña: me.contraseña,
            fNacimiento: me.fNacimiento,
            foto: me.foto
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    }
  }
};
</script>
