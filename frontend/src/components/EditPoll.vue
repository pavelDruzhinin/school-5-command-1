<template>
<v-container>
  <v-row>
  <v-card
    class="mt-10"
    max-width="500"
    outlined
  >
    <v-list-item three-line>
      <v-list-item-content>
        <div class="overline mb-4">Editing Poll [name]</div>
        <v-list-item-title class="headline mb-1">[Headline]</v-list-item-title>
        <v-list-item-subtitle>[Description]: Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione dicta veniam molestiae recusandae repudiandae sit, eligendi exercitationem neque similique aliquam voluptatibus, culpa itaque consequatur officia magni corrupti dolorem necessitatibus nostrum.</v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-card-actions>
      <v-btn 
     class="ml-5"
     small 
     fab 
     dark 
     color="indigo"
     @click="dialog = !dialog">
        <v-icon dark>mdi-plus</v-icon>
      </v-btn>
        <v-card-text> Add Question</v-card-text>

    </v-card-actions>


     <v-dialog v-model="dialog" max-width="400px">
          <v-card class="pt-10">
            <v-card-text>
                <v-form
                ref="form"
                v-model="valid"
                :lazy-validation="lazy"
                >
              <v-text-field
              clear-icon="mdi-close-circle"
              clearable
              :rules="formIsValid"
              v-model="Quest"
              label="Question"
              type="text"
              @click:clear="clearMessage"
              ></v-text-field>
              <v-btn
               class="mr-10" color="indigo"
              @click="submit()">Add</v-btn>
              <v-btn color="indigo" 
              @click="reset();dialog=false">Close</v-btn>
                </v-form>      
            </v-card-text>
          </v-card>
        </v-dialog>

     
    <v-list>
      <v-list-item
       v-for="post in posts"
        :key="post">
       <v-list-item-content>
        <!--     <v-col class="mt-2" cols="5">   -->
            <v-list-item-title> <p>{{post.id}}) {{post.title}}</p></v-list-item-title>
       <!--      </v-col>  -->
        <!--     <v-col cols="2">   -->
          <v-btn-toggle
            v-model="toggle_exclusive"
            class="mx-auto"
            rounded
          >
            <v-btn text icon @click="deletePost(post.title)"><v-icon>mdi-delete</v-icon></v-btn>
            <v-btn text icon @click="dialog2=!dialog2;dialogwrite(post.title)"><v-icon>mdi-pencil</v-icon></v-btn>
          </v-btn-toggle>
      <!--       </v-col>  -->
         <!--      <v-col cols="2">  -->
        <!--       </v-col>  -->
    <!--     </v-row> -->
          </v-list-item-content>
      </v-list-item>
    </v-list> 
    <!--
     <ul v-if="posts && posts.length">
            <li v-for="post in posts" :key="post">
                <p><strong>{{post.title}}</strong></p>
                <p>{{post.body}}</p>
            </li>
        </ul> -->

  </v-card>

  </v-row>
  




</v-container>
</template>


<script>
import axios from 'axios';

  export default {
    data () {
      
      return {
      direction: 'bottom',
      fab: false,
      fling: false,
      hover: false,
      tabs: null,
      top: false,
      right: true,
      bottom: true,
      left: false,
      transition: 'slide-y-reverse-transition',
        dialog: false,
        dialog2:false,
        message:null,
        n:0,
        items:[],
        posts:[],
        errors:[],
        formIsValid: [
          (v) => !!v || 'Field is required'
        ]
      }
    },

    created() {
      axios.get(`https://jsonplaceholder.typicode.com/posts`)
      .then(response=> {
        this.posts= response.data;
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
      })

    },
  



    methods: {
    clearMessage () {
        this.message = ''
      },
    reset () {
        this.$refs.form.reset();
    },
    submit() {
      if(this.$refs.form.validate()) {
        this.posts.push([101,2,this.Quest,3]);
        this.$refs.form.reset();
      }
    },
    deletePost(n) {
      for (let i=0; i<=this.posts.length; i++) {
        if (this.posts[i].title==n) {
          this.posts.splice(i,1);
        }
      }
      
    },
   
    },
    
    }
  
  </script>

  <style>
  /* This is for documentation purposes and will not be needed in your application */
  #create .v-speed-dial {
    position: absolute;
  }
  #create .v-btn--floating {
    position: relative;
  }
</style>