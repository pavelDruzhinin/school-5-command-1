<template>
  <v-container>
    <v-row>
      <v-card class="mt-10" min-width="300" max-width="500" outlined>
        <v-list-item three-line>
          <v-list-item-content>
            <v-img
            :src=bots.image
            class="mx-auto"
            max-width=90px>
            </v-img>
             <v-file-input
      :rules="rules"
      accept="image/png, image/jpeg, image/bmp"
      placeholder="Pick an new avatar"
      prepend-icon="mdi-camera"
      width="10px"
      label="Avatar"
    ></v-file-input>  
            <v-list-item-title class="headline mb-1"> <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="title"
                  label="Title:" type="text" @click:clear="clearMessage"></v-text-field></v-list-item-title>
            <v-list-item-subtitle>
              <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="company"
                  label="Company:" type="text" @click:clear="clearMessage"></v-text-field>
                   <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="position"
                  label="Position:" type="text" @click:clear="clearMessage"></v-text-field>
                   <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="skills"
                  label="Skills required:" type="text" @click:clear="clearMessage"></v-text-field>
                  <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="geo"
                  label="Geo:" type="text" @click:clear="clearMessage"></v-text-field>
              <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="description"
                  label="Description" type="text" @click:clear="clearMessage">
              </v-text-field>
            </v-list-item-subtitle>
            
          </v-list-item-content>
        </v-list-item>

        <v-card-actions>
          <v-btn class="ml-5" small fab dark color="indigo" @click="dialog = !dialog">
            <v-icon dark>mdi-plus</v-icon>
          </v-btn>
          <v-card-text> Add Question</v-card-text>
          <v-btn class="ml-5" small fab dark color="success">
            <v-icon dark>mdi-checkbox-marked-circle</v-icon>
          </v-btn>
          <v-card-text>Submit</v-card-text>


        </v-card-actions>


        <v-dialog v-model="dialog" max-width="400px">
          <v-card class="pt-10">
            <v-card-text>
              <v-form ref="form" v-model="valid" :lazy-validation="lazy">
                <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="Quest"
                  label="Question" type="text" @click:clear="clearMessage"></v-text-field>
                  <div class="text-center">
                <v-btn class="mr-10" color="indigo" @click="submit()">Add</v-btn>
                <v-btn color="indigo" @click="reset();dialog=false">Close</v-btn>
                  </div>
              </v-form>
            </v-card-text>
          </v-card>
        </v-dialog>

        <v-dialog v-model="redactPost" max-width="400px">
          <v-card class="pt-10">
            <v-card-text>
              <v-form ref="form" v-model="valid" :lazy-validation="lazy">
                <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="redQuest"
                  label="Question" type="text" @click:clear="clearMessage"></v-text-field>
                   <div class="text-center">
                <v-btn class="mr-10" color="indigo" @click="redact()">Apply</v-btn>
                <v-btn color="indigo" @click="reset();redactPost=false">Close</v-btn>
                   </div>
              </v-form>
            </v-card-text>
          </v-card>
        </v-dialog>


        <v-list>
          <v-list-item v-for="question in bots.questions" :key="question.questions_id">
            <v-list-item-content>
              <v-list-item-title>
                <p>{{question.title}}</p>
              </v-list-item-title>
              <div class="text-center">
              <v-btn-toggle v-model="toggle_exclusive" class="mx-auto">
                <v-btn text icon @click="deletePost(question.questions_id)">
                  <v-icon>mdi-delete</v-icon>
                </v-btn>
                <v-btn text icon @click="redactPost=!redactPost;dialogwrite(question.title,question.questions_id)">
                  <v-icon>mdi-pencil</v-icon>
                </v-btn>
              </v-btn-toggle>
              </div>

            </v-list-item-content>
          </v-list-item>
          
           
        </v-list>

      <div class="text-center mb-10">
      <v-btn rounded color="success" dark><v-icon class="pr-3">mdi-checkbox-marked-circle</v-icon>Submit</v-btn>
    </div>
      </v-card>
  
    </v-row>

  </v-container>
</template>


<script>
  import axios from 'axios';

  export default {
    data() {

      return {
        direction: 'bottom',
        fab: false,
        globalid: null,
        dialog: false,
        redactPost: false,
        message: null,
        title:null,
        description:null,
        company:null,
        position:null,
        skills:null,
        geo:null,
        n: 0,
        items: [],
        bots: [],
        errors: [],
        redlabel: "",
        formIsValid: [
          (v) => !!v || 'Field is required'
        ]
      }
    },

    created() {
      axios.get(`https://my-json-server.typicode.com/AlexanderPanshin/dpv.school/bots`)
        .then(response => {
          this.bots = response.data[0];
          this.title = this.bots.title,
          this.description = this.bots.description,
          this.company = this.bots.company,
          this.geo = this.bots.geo,
          this.skills = this.bots.skills,
          this.position = this.bots.position

        })
        .catch(error => {
          window.console.log(error);
          this.errored = true;
        })
    },

    methods: {
      clearMessage() {
        this.message = ''
      },
      reset() {
        this.$refs.form.reset();
      },
      submit() {
        if (this.$refs.form.validate()) {
          
          this.bots.questions.push ({
            questions_id:this.bots.questions.length+1,
            title:this.Quest
          });
          this.$refs.form.reset();
        }
      },
      deletePost(n) {
        for (let i = 0; i <= this.bots.questions.length; i++) {
          if (this.bots.questions[i].questions_id == n) {
            this.bots.questions.splice(i, 1);
          }
        }

      },

      redact() {
        if (this.$refs.form.validate()) {
          for (let i = 0; i <= this.bots.questions.length; i++) {
            if (this.bots.questions[i].questions_id == this.globalid) {

              this.bots.questions[i].title = this.redQuest;
            }

          }
        }
      },
      dialogwrite(str, num) {
        this.redQuest = str;
        this.globalid = num;
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