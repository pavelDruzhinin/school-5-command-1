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
          <v-btn class="ml-5" small fab dark color="success" @click="sucess=!sucess">
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

         <v-dialog v-model="sucess" max-width="400px">
          <v-card class="pt-10">
            <v-card-text>
              
                  <div class="text-center">
                Sucess
                  </div>
            </v-card-text>
            <div class="text-center">
            <v-btn class="mb-10" @click="sucess=!sucess">Close</v-btn>
            </div>
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
          <v-list-item v-for="question in questions" :key="question.questions_id">
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
      <v-btn rounded color="success" dark  @click="sucess=!sucess"><v-icon class="pr-3" >mdi-checkbox-marked-circle</v-icon>Submit</v-btn>
    </div>
      </v-card>
  
    </v-row>

  </v-container>
</template>


<script>

  export default {
    data() {

      return {
        direction: 'bottom',
        fab: false,
        globalid: null,
        dialog: false,
        sucess:false,
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
        bots: [{id:{},title:{},company:{},userpassed:{},questions_num:{},createdate:{},canceled:{},image:{},description:{}}],
       questions: [], /* {questions_id:null,title:null} */
       errors: [],
        redlabel: "",
        formIsValid: [
          (v) => !!v || 'Field is required'
        ]
      }
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
          
          this.questions.push ({
            questions_id:this.questions.size,
            title:this.Quest
          });
          this.$refs.form.reset();
        }
      },
      deletePost(n) {
        for (let i = 0; i <= this.questions.length; i++) {
          if (this.questions[i].questions_id == n) {
            this.questions.splice(i, 1);
          }
        }

      },

      redact() {
        if (this.$refs.form.validate()) {
          for (let i = 0; i <= this.questions.length; i++) {
            if (this.questions[i].questions_id == this.globalid) {

              this.questions[i].title = this.redQuest;
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