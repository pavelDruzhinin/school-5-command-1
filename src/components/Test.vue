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
        <div class="overline mb-4">Creating Poll [name]</div>
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
<v-speed-dial
      class="mt-8"
      v-model="fab"
      :top="top"
      :bottom="bottom"
      :right="right"
      :left="left"
      :direction="direction"
      :open-on-hover="hover"
      :transition="transition"
    >
      <template v-slot:activator>
        <v-btn
          v-model="fab"
          color="warning"
          small
          dark
          fab
        >
          <v-icon v-if="fab">mdi-close</v-icon>
          <v-icon v-else>mdi-settings</v-icon>
        </v-btn>
      </template>
      <v-btn
        fab
        dark
        small
        color="green"
      >
        <v-icon>mdi-pencil</v-icon>
      </v-btn>
     
      <v-btn
        fab
        dark
        small
        color="red"
      >
        <v-icon>mdi-delete</v-icon>
      </v-btn>
    </v-speed-dial>
      
      <v-card-text class="pl-0">Redact Questions</v-card-text>
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

            <v-card-actions>
              <v-spacer></v-spacer>
              
              
            </v-card-actions>
          </v-card>
        </v-dialog>

    <v-list>
      <v-list-item
       v-for="item in items"
        :key="item">
       <v-list-item-content>
            <v-list-item-title v-text="item"></v-list-item-title>
          </v-list-item-content>
      </v-list-item>
    </v-list>

  </v-card>

  </v-row>
  
</v-container>
</template>


<script>
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
        message:null,
        n:0,
        items:[],
        formIsValid: [
          (v) => !!v || 'Field is required'
        ]
      }
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
        this. items.push(this.Quest);
        this.$refs.form.reset();
      }
    }
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