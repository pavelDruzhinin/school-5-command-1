<template>
  <v-card
    class="ms-10 mt-10"
    max-width="500"
    outlined
  >
    <v-list-item three-line>
      <v-list-item-content>
        <div class="overline mb-4">Creating Poll [name]</div>
        <v-list-item-title class="headline mb-1">[Headline]</v-list-item-title>
        <v-list-item-subtitle>Description: Lorem ipsum dolor sit amet consectetur adipisicing elit. Ratione dicta veniam molestiae recusandae repudiandae sit, eligendi exercitationem neque similique aliquam voluptatibus, culpa itaque consequatur officia magni corrupti dolorem necessitatibus nostrum.</v-list-item-subtitle>
      </v-list-item-content>

      <v-list-item-avatar
        tile
        size="80"
        color="grey"
      ></v-list-item-avatar>
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
      <v-btn
      small
      fab
      dark
      color="warning">
          <v-icon dark>mdi-pencil</v-icon>
      </v-btn>
      <v-card-text>Redact Questions</v-card-text>
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
              v-model="Quest"
              label="Question"
              type="text"
              required
              @click:clear="clearMessage"
              ></v-text-field>
              <v-btn class="mr-10" color="indigo"
              @click="items.push(Quest)">Add</v-btn>
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
  

</template>


<script>
  export default {
    data () {
      
      return {
        dialog: false,
        message:null,
        n:0,
        items:[]
      }
    },

    methods: {
    clearMessage () {
        this.message = ''
      },
    reset () {
        this.$refs.form.reset();
    }
    },
    }
  
  </script>