<template>
  <v-app id="inspire" dark>
   
    <v-toolbar app fixed clipped-left>
      <v-toolbar-title>Roffus Design Room</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn color="info" to="/login">Iniciar Sesion</v-btn>
    </v-toolbar>
    <v-content>
     <v-container fluid>
           <v-card flat light color="blue">
           <v-card-text class="display-4 text-lg-center"  >
                 Bienvenido a Roffus Design Room
              </v-card-text> 
         </v-card>
         <br>
         <v-layout wrap="true" >
             <v-flex lg8>
                 <v-img 
                      :src="require('../assets/ejemplan2d.jpg')"
                ></v-img>
             </v-flex>   
             <v-card flat light color="error" max-width=400>
               <v-card-text class="display-2 "  >
                 Renueva tu habitación con tus propias ideas
              </v-card-text> 
              <v-card-text class="subheading text-lg-center"  >
               Aquí podrás encontrar productos reales de diferentes distribuidores,
                con los culaes podrás renovar el espíritu de tu habitación diseñandolo fácilmente con tus ideas
              </v-card-text> 
               <v-card-actions>
                   <v-btn flat color="black">Comenzar</v-btn>
               </v-card-actions>
              
             </v-card>
              
         </v-layout>   
         <br>
        <v-layout justify-end>
           <v-card flat light color="warning" max-width=400>
              <v-card-text  class="subheading text-lg-center"  >
                Si desea decorar su habitacion con productos de distribuidores como Maestro, Sodimac y Promart, aqui podras encontrarlos.
                Además, podrás verificar si poseen las dimensiones correctas para ir en tu habitación gracias a nuestro Modelador 2D
              </v-card-text> 
             </v-card>
             <v-flex lg8 >
                 <v-img
                      :src="require('../assets/hab1.jpg')"
                ></v-img>
             </v-flex>    
            

         </v-layout>  
     </v-container>    
    </v-content>
    <v-footer app fixed>
      <span>&copy; 2019</span>
    </v-footer>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      drawer: null,
      
    
    }),
    props: {
      source: String
    }
  }
</script>