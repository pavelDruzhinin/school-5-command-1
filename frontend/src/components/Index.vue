<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="4" md="4">
        <v-layout
                text-center
                wrap
        >

          <v-flex mb-4>
            <h1 class="display-2 font-weight-bold mb-3">
              Welcome to Chatbots APP
            </h1>
            <p class="subheading font-weight-regular">
              Service to manage your bots in one place
            </p>
            <v-layout row class="text-xs-center"
                      text-center
                      wrap
            >
              <v-flex xs-2>
                <v-card flat>
                  <v-form>
                    <v-col cols="12" sm="12" md="12">
                      <v-text-field label="Username" required></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="12" md="12">
                      <v-text-field label="Password" required></v-text-field>
                    </v-col>
                    <v-card-actions>
                      <v-btn primary large block>Login</v-btn>
                    </v-card-actions>
                  </v-form>
                </v-card>
              </v-flex>
            </v-layout>
          </v-flex>
        </v-layout>
      </v-col>
      <v-spacer></v-spacer>
      <v-col cols="12" sm="8" md="8">
        <v-timeline :dense="$vuetify.breakpoint.smAndDown">
          <v-timeline-item
                  color="purple lighten-2"
                  fill-dot
                  right
          >
            <v-card>
              <v-card-title class="purple lighten-2">
                <v-icon
                        dark
                        size="42"
                        class="mr-4"
                >
                  mdi-account
                </v-icon>
                <h2 class="headline white--text font-weight-light">Sign UP</h2>
              </v-card-title>
              <v-container>
                <v-row>
                  <v-col cols="12" md="12">
                    Sign UP or login in App
                  </v-col>
                </v-row>
              </v-container>
            </v-card>
          </v-timeline-item>

          <v-timeline-item
                  color="green lighten-1"
                  fill-dot
                  right
          >
            <v-card>
              <v-card-title class="green lighten-1">
                <v-icon
                        dark
                        size="42"
                        class="mr-4"
                >
                  mdi-view-grid-plus-outline
                </v-icon>
                <h2 class="headline white--text font-weight-light">Add your bots</h2>
              </v-card-title>
              <v-container>
                <v-row>
                  <v-col cols="12" md="12">
                    Or start conversation with bots
                  </v-col>
                </v-row>
              </v-container>
            </v-card>
          </v-timeline-item>

          <v-timeline-item
                  color="cyan lighten-1"
                  fill-dot
                  right
          >
            <v-card>
              <v-card-title class="cyan lighten-1">
                <v-icon
                        class="mr-4"
                        dark
                        size="42"
                >
                  mdi-file-tree
                </v-icon>
                <h2 class="headline white--text font-weight-light">Manage</h2>
              </v-card-title>
              <v-container>
                <v-row>
                  <v-col cols="12" md="12">
                    Bla bla bla
                  </v-col>
                </v-row>
              </v-container>
            </v-card>
          </v-timeline-item>
        </v-timeline>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    data: () => ({}),
  }
</script>

<style>
  .v-application .mb-6 {
    margin-bottom: 26px !important;
  }
</style>
